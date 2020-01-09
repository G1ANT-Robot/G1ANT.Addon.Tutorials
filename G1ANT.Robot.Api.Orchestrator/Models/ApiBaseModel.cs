using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G1ANT.Robot.Api.Orchestrator.Data;

namespace G1ANT.Robot.Api.Orchestrator.Models
{
    public class ApiBaseModel
    {
        private string serial;
        public string Serial 
        { 
            get
            {
                return serial;
            }
            set
            {
                serial = value.Trim().ToUpper();
                robot = null;
                foreach(var item in Data.Data.Robots)
                    if (serial == item.SerialNumber.Trim().ToUpper())
                    {
                        robot = item;
                        return;
                    }
            }
        }

        private string type = null;
        public string Type 
        { 
            get
            {
                return type;
            }
            set
            {
                var items = value.Trim().Split('.');
                type = items[items.Length - 1];
                type = type.Substring(0, type.Length - "Event".Length);
            }
        }

        private G1ANT.Robot.Api.Orchestrator.Data.Robot robot = null;
        public G1ANT.Robot.Api.Orchestrator.Data.Robot Robot 
        { 
            get { return robot; } 
        }
    }
}
