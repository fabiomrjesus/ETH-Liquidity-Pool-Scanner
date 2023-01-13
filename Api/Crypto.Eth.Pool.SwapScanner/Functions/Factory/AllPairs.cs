using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Crypto.Eth.Pool.SwapScanner.Functions.Factory
{
    /// <summary>
    /// Fetches a pair based on its index
    /// </summary>
    [Function("allPairs", "address")]
    internal class AllPairs : FunctionMessage
    {

        [Parameter("uint256", "", 1, true)]
        public ulong Index { get; set; }
    }
}
