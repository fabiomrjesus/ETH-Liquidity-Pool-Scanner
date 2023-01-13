namespace Crypto.Eth.Pool.SwapScanner.Exceptions
{
    public class InvalidIndexException : Exception
    {
        public InvalidIndexException(ulong index) :base ($"Index is not valid : {index}"){ }
    }
}
