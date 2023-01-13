using Crypto.Eth.Pool.SwapScanner.Model;
using Newtonsoft.Json;

namespace Crypto.Eth.Pool.SwapScanner.Exceptions
{
    public class InvalidPairException : Exception
    {
        public InvalidPairException(Pair pair) : base($"The pair is not valid. Expected pairs shoud have a valid pair address or two valid token addresses. {JsonConvert.SerializeObject(pair)}") { }
    }
}
