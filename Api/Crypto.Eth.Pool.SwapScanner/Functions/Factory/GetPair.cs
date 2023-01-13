using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Crypto.Eth.Pool.SwapScanner.Functions.Factory
{
    /// <summary>
    /// Fetches a pair based on its tokens' addresses
    /// </summary>
    internal class GetPair : FunctionMessage
    {
        [Parameter("address", "", 1, true)]
        public string? Token0 { get; set; }

        [Parameter("address", "", 2, true)]
        public string? Token1 { get; set; }
    }
}
