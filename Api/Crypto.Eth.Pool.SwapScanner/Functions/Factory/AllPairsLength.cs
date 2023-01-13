using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Crypto.Eth.Pool.SwapScanner.Functions.Factory
{
        /// <summary>
        /// Fetches a pair based on its index
        /// </summary>
    [Function("allPairsLength", "uint256")]
    internal class AllPairsLength : FunctionMessage
    {
    }
}
