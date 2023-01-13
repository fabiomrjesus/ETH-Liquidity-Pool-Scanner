using Crypto.Eth.Pool.SwapScanner.Model;

namespace Crypto.Eth.Pool.SwapScanner.Interfaces
{
    public interface ISwapScanner
    {
        /// <summary>
        /// Number of pools registered in the swap
        /// </summary>
        public Task<ulong> GetAvailablePairCount();

        /// <summary>
        /// Fetches the pair based on its address
        /// </summary>
        public Task<Pair> GetPair(string address);
        
        /// <summary>
        /// Fetches a pair based on its index
        /// </summary>
        public Task<Pair> GetPair(ulong index);


        /// <summary>
        /// Fetches a pair based on its tokens' addresses
        /// </summary>
        public Task<Pair> GetPair(string leftTokenAddress, string rightTokenAddress);


        /// <summary>
        /// Updates a list of pairs where either the pair address is missing or both token addresses are missing
        /// </summary>
        public Task<List<Pair>> Update(List<Pair> pairs, bool skipInvalidPairs = false, bool skipOnFail = false);

        /// <summary>
        /// Initiates a scan from a position (1 by default)
        /// </summary>
        public Task<List<Pair>> Scan(ulong startAt = 1, bool skipOnFail = false);

        /// <summary>
        /// Initiates a scan from a position to another
        /// </summary>
        public Task<List<Pair>> Scan(ulong startAt, ulong lastIndexOf, bool skipOnFail = false);



    }
}
