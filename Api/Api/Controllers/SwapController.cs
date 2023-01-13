using Crypto.Eth.Pool.SwapScanner.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwapController : ControllerBase
    {
        private readonly ISwapScanner _scanner;
        private readonly ILogger<SwapController> _logger;
        public SwapController(ILogger<SwapController> logger, ISwapScanner scanner)
        {
            _scanner = scanner;
            _logger = logger;
        }

        [HttpGet()]
    }
}