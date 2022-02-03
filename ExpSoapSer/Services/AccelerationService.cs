using ExpSoapSer.Interfaces;
using ExpSoapSer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpSoapSer.Services
{
    public class AccelerationService : IAccelerationService
    {
        public AccelerationService()
        {

        }
        public string Speed(string s)
        {
            Console.WriteLine(s + " MPH");
            return s;
        }

        public MachineModel TestMachine(MachineModel model)
        {
            return model;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}
