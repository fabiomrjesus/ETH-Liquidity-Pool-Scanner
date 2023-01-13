namespace Crypto.Eth.Pool.SwapScanner.Model.Requests
{
    public class RecoveryRequest
    {
        public ulong RecoveryWindow { get; set; } = 0;
        public uint Recoveries { get; set; } = 0;
        public bool SkipOnFail { get; set; } = false;
    }
}
