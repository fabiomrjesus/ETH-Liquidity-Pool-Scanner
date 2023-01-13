using Crypto.Eth.Pool.SwapScanner.Exceptions;
using Crypto.Eth.Pool.SwapScanner.Interfaces;
using Crypto.Eth.Pool.SwapScanner.Model;
using Crypto.Eth.Pool.SwapScanner.Operations;
using Nethereum.Util;
using Nethereum.Web3;

namespace Crypto.Eth.Pool.SwapScanner
{
    public class SwapScanner : ISwapScanner
    {
        public readonly ISwapScannerSettings _settings;
        public readonly AddressUtil _addressUtil;

        /// <summary>
        /// Throws an exception if the address is not a valid format for contracts
        /// </summary>
        private void ValidateAddress(string name, string address)
        {
            if(_addressUtil.IsValidAddressLength(address) ||
               _addressUtil.IsAnEmptyAddress(address) ||
               _addressUtil.IsValidEthereumAddressHexFormat(address))
                throw new InvalidAddressException(name, address);
        }

        /// <summary>
        /// Validates a ulong index
        /// </summary>
        private static void ValidateIndex(ulong index)
        {
            if (index <1)
                throw new InvalidIndexException(index);
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        public SwapScanner(ISwapScannerSettings settings)
        {
            _addressUtil = new();
            ValidateAddress("FACTORY", settings.FactoryAddress);
            _settings = settings;
        
        }

        /// <summary>
        /// Number of pools registered in the swap
        /// </summary>
        public async Task<ulong> GetAvailablePairCount()
        {
            var web3 = new Web3(_settings.RpcUrl);
            var operations = new FactoryContractOperations(web3, _settings.FactoryAddress);
            return await operations.GetPairCount();
        }

        /// <summary>
        /// Fetches the pair based on its address
        /// </summary>
        public async Task<Pair> GetPair(string address)
        {
            ValidateAddress("PAIR", address);
            var web3 = new Web3(_settings.RpcUrl);
            var operations = new PairContractOperations(web3, address);
            var tokenLeft = await operations.GetToken0();
            var tokenRight = await operations.GetToken1();
            return new Pair() { LeftTokenAddress=tokenLeft, RightTokenAddress=tokenRight, PairAddress = address};
        }

        /// <summary>
        /// Fetches a pair based on its index
        /// </summary>
        public async Task<Pair> GetPair(ulong index)
        {
            ValidateIndex(index);
            var web3 = new Web3(_settings.RpcUrl);
            var operations = new FactoryContractOperations(web3, _settings.FactoryAddress);
            var pairAddress = await operations.GetPair(index);
            var pair = await GetPair(pairAddress);
            return pair;
        }

        /// <summary>
        /// Fetches a pair based on its tokens' addresses
        /// </summary>
        public async Task<Pair> GetPair(string leftTokenAddress, string rightTokenAddress)
        {
            ValidateAddress("LEFT", leftTokenAddress);
            ValidateAddress("RIGHT", rightTokenAddress);

            var web3 = new Web3(_settings.RpcUrl);
            var operations = new FactoryContractOperations(web3, _settings.FactoryAddress);
            var result = await operations.GetPair(leftTokenAddress, rightTokenAddress);
            return new Pair() { LeftTokenAddress = leftTokenAddress, RightTokenAddress = rightTokenAddress, PairAddress= result };
        }

        /// <summary>
        /// Updates a list of pairs where either the pair address is missing or both token addresses are missing
        /// </summary>
        public async Task<List<Pair>> Scan(ulong startAt = 1, bool skipOnFail = false)
        {
            ValidateIndex(startAt);
            var result = new List<Pair>();
            var current = startAt;
            var last = await GetAvailablePairCount();
            while(current < last+1) 
            {
                var pair = await GetPair(current);
                result.Add(pair);
                if(current == last)
                {
                    last = await GetAvailablePairCount();
                }
            }
            return result;
        }

        /// <summary>
        /// Initiates a scan from a position (1 by default)
        /// </summary>
        public async Task<List<Pair>> Scan(ulong startAt, ulong lastIndexOf, bool skipOnFail = false)
        {
            ValidateIndex(startAt);
            ValidateIndex(lastIndexOf);
            var result = new List<Pair>();
            var current = startAt;
            while (current < lastIndexOf + 1)
            {
                try
                {
                    var pair = await GetPair(current);
                    result.Add(pair);
                }
                catch
                {
                    if (skipOnFail) throw; else continue;
                }
            }
            return result;
        }

        /// <summary>
        /// Initiates a scan from a position to another
        /// </summary>
        public async Task<List<Pair>> Update(List<Pair> pairs, bool skipInvalidPairs = false, bool skipOnFail=false)
        {
            var result = new List<Pair>();
            foreach (var pair in pairs)
            {
                if (!string.IsNullOrEmpty(pair.PairAddress) &&
                   !string.IsNullOrEmpty(pair.LeftTokenAddress) &&
                   !string.IsNullOrEmpty(pair.RightTokenAddress))
                {
                    result.Add(pair);
                }
                else if (!string.IsNullOrEmpty(pair.PairAddress) &&
                   string.IsNullOrEmpty(pair.LeftTokenAddress) &&
                   string.IsNullOrEmpty(pair.RightTokenAddress))
                {
                    try
                    {
                        var pairResult = await GetPair(pair.PairAddress);
                        result.Add(pairResult);
                    }
                    catch
                    {
                        if (skipOnFail) throw; else continue;
                    }
                }
                else if (string.IsNullOrEmpty(pair.PairAddress) &&
                   !string.IsNullOrEmpty(pair.LeftTokenAddress) &&
                   !string.IsNullOrEmpty(pair.RightTokenAddress))
                {
                    try
                    {
                        var pairResult = await GetPair(pair.LeftTokenAddress, pair.RightTokenAddress);
                        result.Add(pairResult);
                    }
                        catch
                    {
                        if (skipOnFail) throw; else continue;
                    }
                }
                else { 
                    if(skipInvalidPairs) continue;
                    throw new InvalidPairException(pair); 
                }
            }
            return result;
        }
    }
}
