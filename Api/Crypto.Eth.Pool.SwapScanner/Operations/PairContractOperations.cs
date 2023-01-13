using Crypto.Eth.Pool.SwapScanner.Functions.Pair;
using Nethereum.Web3;

namespace Crypto.Eth.Pool.SwapScanner.Operations
{
    internal class PairContractOperations
    {
        private readonly Web3 _web3;
        private readonly string _pairTokenAddress;
        internal PairContractOperations(Web3 webThreeInstance, string pairTokenAddress)
        {
            _web3 = webThreeInstance;
            _pairTokenAddress = pairTokenAddress;
        }

        /// <summary>
        /// Fetches the token at the 0 position
        /// </summary>
        public async Task<string> GetToken0()
        {
            var tokenMessage = new Token0();
            var handler = _web3.Eth.GetContractQueryHandler<Token0>();
            var result = await handler.QueryAsync<string>(_pairTokenAddress, tokenMessage);
            return result;
        }

        /// <summary>
        /// Fetches the token at the 1 position
        /// </summary>
        public async Task<string> GetToken1()
        {
            var tokenMessage = new Token1();
            var handler = _web3.Eth.GetContractQueryHandler<Token1>();
            var result = await handler.QueryAsync<string>(_pairTokenAddress, tokenMessage);
            return result;
        }
    }
}
