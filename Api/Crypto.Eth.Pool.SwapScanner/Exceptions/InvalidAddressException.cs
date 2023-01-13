namespace Crypto.Eth.Pool.SwapScanner.Exceptions
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string name, string address) : base($"Invalid address for {name} : {address}") { }
    }
}
