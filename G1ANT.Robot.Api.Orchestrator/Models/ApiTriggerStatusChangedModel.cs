using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class ApiTriggerStatusChangedModel : ApiBaseModel
    {
        public bool IsEnabled { get; set; }
    }
}
