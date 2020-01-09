using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class ApiProcessStopModel : ApiBaseModel
    {
        public string ProcessName { get; set; }
        public DateTime FinishDateTime { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public string Status { get; set; }
        public string Error { get; set; }
    }
}
