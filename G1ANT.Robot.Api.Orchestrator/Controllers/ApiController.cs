using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using G1ANT.Robot.Api.Orchestrator.Models;
using G1ANT.Robot.Api.Orchestrator.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace G1ANT.Robot.Api.Orchestrator.Controllers
{
    [Route("api/{action}")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private void AddEvent(ApiBaseModel model, string description)
        {
            Data.Data.Events.Add(new Data.Event()
            {
                Name = model.Type,
                SerialNumber = model.Serial,
                When = DateTime.Now.ToString(),
                Description = description
            });
        }

        [HttpPost]
        public string CommandExecuted([FromBody] ApiCommandExecutedModel model)
        {
            AddEvent(model, $"LineNo: {model.LineNumber}");
            return "OK";
        }

        [HttpPost]
        public string TriggerRaised([FromBody] ApiTriggerRaisedModel model)
        {
            AddEvent(model, $"Trigger: {model.TriggerName}");
            return "OK";
        }

        [HttpPost]
        public string TriggerStatusChanged([FromBody] ApiTriggerStatusChangedModel model)
        {
            AddEvent(model, $"Enabled: {model.IsEnabled}");
            return "OK";
        }

        [HttpPost]
        public string ProgramStatusChanged([FromBody] ApiProgramStatusChangedModel model)
        {
            AddEvent(model, $"Status: {model.ProgramStatus}");
            return "OK";
        }

        [HttpPost]
        public string ProcessStop([FromBody] ApiProcessStopModel model)
        {
            AddEvent(model, $"Process: {Path.GetFileName(model.ProcessName)}, Finish: {model.FinishDateTime}, Execution: {model.ExecutionTime}, Status: {model.Status}, Error: {model.Error}");
            return "OK";
        }

        [HttpPost]
        public string ProcessStart([FromBody] ApiProcessStartModel model)
        {
            AddEvent(model, $"Process: {Path.GetFileName(model.ProcessName)}, IsTriggered: {model.IsTriggered}, Start: {model.StartDateTime}");
            return "OK";
        }
    }
}
