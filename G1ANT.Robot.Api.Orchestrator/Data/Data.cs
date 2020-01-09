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

        public static List<Robot> Robots { get; } = new List<Robot>();

        public static Robot CurrentRobot { get; set; } = null;
    }
}