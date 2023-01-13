using Crypto.Eth.Pool.SwapScanner.Functions.Factory;
using Nethereum.Web3;
using System.Numerics;

namespace Crypto.Eth.Pool.SwapScanner.Operations
{
    internal class FactoryContractOperations
    {
        private readonly Web3 _web3;
        private readonly string _factoryContractAddress;
        internal FactoryContractOperations(Web3 webThreeInstance, string factoryContractAddress) 
        {
            _web3 = webThreeInstance;
            _factoryContractAddress = factoryContractAddress;
        }

        /// <summary>
        /// Number of pools registered in the swap
        /// </summary>
        public async Task<ulong> GetPairCount() 
        {
            var pairCountFunctionMessage = new AllPairsLength();
            var handler = _web3.Eth.GetContractQueryHandler<AllPairsLength>();
            var result = await handler.QueryAsync<BigInteger>(_factoryContractAddress, pairCountFunctionMessage);
            return (ulong)result;
        }

        /// <summary>
        /// Fetches a pair based on its index
        /// </summary>
        public async Task<string> GetPair(ulong index) 
        {
            var pairFunctionMessage = new AllPairs() { Index = index};
            var handler = _web3.Eth.GetContractQueryHandler<AllPairs>();
            var result = await handler.QueryAsync<string>(_factoryContractAddress, pairFunctionMessage);
            return result;
        }

        /// <summary>
        /// Fetches a pair based on its tokens' addresses
        /// </summary>
        public async Task<string> GetPair(string token0, string token1) 
        {
            var pairFunctionMessage = new GetPair() { Token0 = token0, Token1=token1};
            var handler = _web3.Eth.GetContractQueryHandler<GetPair>();
            var result = await handler.QueryAsync<string>(_factoryContractAddress, pairFunctionMessage);
            return result;
        }
    }
}
