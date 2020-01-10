using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class RobotQueryModel : DefaultModel
    {
        public string Query { get; set; } = "";
        public string Method { get; set; } = "";
        public string Parameters { get; set; } = "";
        public string Result { get; set; } = "";
        public string Body { get; set; } = "";
        public byte[] BodyFile { get; set; }
    }
}
