using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace Crypto.Eth.Pool.SwapScanner.Functions.Pair
{
    /// <summary>
    /// Fetches the token at the 0 position
    /// </summary>
    [Function("token0", "address")]
    public class Token0 : FunctionMessage
    {

    }
}
