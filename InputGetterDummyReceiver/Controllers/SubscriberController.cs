using Microsoft.AspNetCore.Mvc;
using TE.Events;

namespace InputGetterDummyReceiver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriberController : ControllerBase
    {
        private readonly ILogger<SubscriberController> _logger;

        public SubscriberController(ILogger<SubscriberController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult FileReceivedEvent(FileReceivedEvent e)
        {
            if (e?.Lines is null || e.Lines == Array.Empty<string>())
            {
                _logger.LogWarning("\"FileReceivedEvent was empty.");
                return BadRequest("FileReceivedEvent was empty.");
            }

            _logger.LogInformation($"Received {e.OriginalFile}:\r\n{string.Join("\r\n", e.Lines)}");

            return NoContent();
        }
        
    }
}