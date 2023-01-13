using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;


namespace Crypto.Eth.Pool.SwapScanner.Functions.Pair
{

    /// <summary>
    /// Fetches the token at the 1 position
    /// </summary>
    [Function("token1", "address")]
    internal class Token1 : FunctionMessage
    {
    }
}
