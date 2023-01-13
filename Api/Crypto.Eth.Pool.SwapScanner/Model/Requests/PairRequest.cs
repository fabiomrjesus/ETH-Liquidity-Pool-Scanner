namespace Crypto.Eth.Pool.SwapScanner.Model.Requests
{
    public class PairRequest : RecoveryRequest
    {
        public string PairAddress { get; } 
        public string LeftmTokenAddress { get; } 
        public string RightTokenAddress { get; }
        public ulong Index { get; }


        public PairRequest(string pairAddress) { }
        public PairRequest(ulong index) { }
        public PairRequest(string leftTokenAddress, string rightTokenAddress) { }

    }
}
