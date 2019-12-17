using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace G1ANT.Robot.Api.Orchestrator.Data
{
    public static class Data
    {
        public static List<Event> Events { get; } = new List<Event>();

        public static List<Robot> Robots { get; } = new List<Robot>()
        {
            new Robot("localhost", 1234, "9CE84FC88CB006", "9CE867D195B02E")
        };
    }
}
