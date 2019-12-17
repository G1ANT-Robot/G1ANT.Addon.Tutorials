using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1ANT.Robot.Api.Orchestrator.Data
{
    public class Event
    {
        public string SerialNumber { get; set; }
        public string When { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
