using System;
using Microsoft.AspNetCore.Mvc;
namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }       

        /// <summary>
        /// Test Controller
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST# Command Service");
            return Ok("Inbound test ok from Platforms Controller");
        }
    }
}