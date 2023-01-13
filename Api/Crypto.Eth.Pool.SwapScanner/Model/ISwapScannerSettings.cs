namespace Crypto.Eth.Pool.SwapScanner.Model
{
    public interface ISwapScannerSettings
    {
        public string RpcUrl { get; set; }
        public string FactoryAddress { get; set; }

    }
}
