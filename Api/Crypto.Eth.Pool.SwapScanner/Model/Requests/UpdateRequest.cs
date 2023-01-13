namespace Crypto.Eth.Pool.SwapScanner.Model.Requests
{
    public class UpdateRequest : RecoveryRequest
    {
        public List<Pair> PairsToUpdate { get; set; }
        public bool FetchPairsBetween { get; set; }
    }
}
