using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G1ANT.Robot.Api.Orchestrator.Connector;

namespace G1ANT.Robot.Api.Orchestrator.Data
{
    public class Robot
    {
        public string SerialNumber { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Machine { get; set; } = "localhost";
        public int Port { get; set; } = 1234;

        public List<string> SubscribedEvents { get; } = new List<string>()
        {
            "TriggerStatusChanged",
            "TriggerRaised",
            "ProgramStatusChanged",
            "ProcessStop",
            "ProcessStart",
            "CommandExecutedEvent"
        };

        public void Subscribe(string baseUrl)
        {
            foreach(var eventName in SubscribedEvents)
            {
                string xml = $"<Subscription event=\"{eventName}\"><Url>{baseUrl}/api/event</Url><Subscription>";
            }
        }

        public bool Active
        {
            get
            {
                try
                {
                    string result = new ApiClient(Machine, Port, SerialNumber, Token).Get("/");
                    return result == "Running";
                }
                catch
                {
                    return false;
                }
            }
        }

        public Robot(string machine, int port, string serialNumber, string token)
        {
            Machine = machine;
            Port = port;
            Token = token;
            SerialNumber = serialNumber;
        }
    }
}
