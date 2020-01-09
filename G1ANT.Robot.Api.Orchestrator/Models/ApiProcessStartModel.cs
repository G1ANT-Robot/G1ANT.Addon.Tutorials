using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Json;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class ApiProcessStartModel : ApiBaseModel
    {
        public string ProcessName { get; set; }
        public DateTime StartDateTime { get; set; }
        public bool IsTriggered { get; set; }
    }
}