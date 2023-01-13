namespace Crypto.Eth.Pool.SwapScanner.Model
{
    /// <summary>
    /// Representation of a pair address that contains both token addresses and a pair address for future use
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// The pair's index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The pair address
        /// </summary>
        public string? PairAddress { get; set; }
        /// <summary>
        /// One of the pair's token address
        /// </summary>
        public string? LeftTokenAddress { get; set; }

        /// <summary>
        /// One of the pair's token address
        /// </summary>
        public string? RightTokenAddress { get; set; }
    }
}
