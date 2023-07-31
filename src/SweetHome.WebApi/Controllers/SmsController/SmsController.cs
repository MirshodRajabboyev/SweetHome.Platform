using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetHome.Service.Dtos.Notification;
using SweetHome.Service.Interfaces.Notification;

namespace SweetHome.WebApi.Controllers.SmsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsSender _smsSender;

        public SmsController(ISmsSender smsSender)
        {
            _smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendsmsAsync(smsMessage));
        }
    }
}
