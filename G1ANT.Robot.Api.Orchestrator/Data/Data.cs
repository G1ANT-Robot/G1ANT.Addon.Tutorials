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

        private static string serialNumber;
        public static string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value.Trim().ToUpper();
                currentRobot = null;
                foreach (var item in Robots)
                    if (serialNumber == item.SerialNumber.Trim().ToUpper())
                    {
                        currentRobot = item;
                        return;
                    }

            }
        }

        private static Robot currentRobot;
        public static Robot CurrentRobot 
        {
            get { return currentRobot; }
        }
    }
}