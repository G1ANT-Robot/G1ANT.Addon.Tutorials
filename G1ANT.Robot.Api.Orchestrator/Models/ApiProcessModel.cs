using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Json;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    [Serializable]
    public class ApiProcessModel : ApiBaseModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Location { get; set; }
    }
}
