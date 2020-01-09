using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using G1ANT.Robot.Api.Orchestrator.Models;
using System.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace G1ANT.Robot.Api.Orchestrator.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpPost]
        public string Event()
        {
            return "OK";
        }

        [HttpPost]
        public string TriggerStatusChanged()
        {
            return "OK";
        }

        [HttpPost]
        // [FromBody] ApiProcessModel model
        public string ProcessStart()
        {
            string body;
            HttpContext.Request.EnableBuffering();
            Request.Body.Position = 0;
            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                var task = stream
                    .ReadToEndAsync()
                    .ContinueWith(t => {
                        body = t.Result;
                    });
                task.Wait();
            }
            return "OK";
        }
    }
}
