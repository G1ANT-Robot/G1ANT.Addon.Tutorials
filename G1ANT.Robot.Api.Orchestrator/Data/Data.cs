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
                serialNumber = value?.Trim().ToUpper();
                if (!string.IsNullOrWhiteSpace(serialNumber))
                {
                    currentRobot = null;
                    foreach (var item in Robots)
                        if (serialNumber == item.SerialNumber.Trim().ToUpper())
                        {
                            currentRobot = item;
                            return;
                        }
                }
            }
        }

        private static Robot currentRobot;
        public static Robot CurrentRobot 
        {
            get 
            {
                if (currentRobot == null && Robots.Count > 0)
                    currentRobot = Robots[0];
                return currentRobot; 
            }
        }
    }
}