using ExpSoapSer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpSoapSer.Interfaces
{
    [ServiceContract]
    public interface IAccelerationService
    {
        [OperationContract]
        string Speed(string s);

        [OperationContract]
        void XmlMethod(XElement xml);

        [OperationContract]
        MachineModel TestMachine(MachineModel model);
    }
}
