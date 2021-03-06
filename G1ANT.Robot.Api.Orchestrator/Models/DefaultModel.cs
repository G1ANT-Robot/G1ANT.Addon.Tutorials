﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using G1ANT.Robot.Api.Orchestrator.Data;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class DefaultModel
    {
        public string Information { get; set; }

        public string InformationClass { get; set; }

        public string SerialNumber 
        {
            get
            {
                return Data.Data.SerialNumber;
            }
            set
            {
                Data.Data.SerialNumber = value;
            }
        }

        public Data.Robot Robot { 
            get 
            {
                return Data.Data.CurrentRobot;
            }
        }
    }
}
