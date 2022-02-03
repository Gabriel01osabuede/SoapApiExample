using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ExpSoapSer.Models
{
    [DataContract]
    public class ManufacturalModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public int MachineId { get; set; }
        [DataMember]
        public MachineModel Machine { get; set; }
    }
}
