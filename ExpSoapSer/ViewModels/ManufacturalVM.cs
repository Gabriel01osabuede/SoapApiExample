using ExpSoapSer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpSoapSer.ViewModels
{
    public class ManufacturalVM
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public MachineModel Machine { get; set; }

        public static implicit operator ManufacturalVM(Models.ManufacturalModel model)
        {
            return model == null ? null : new ManufacturalVM
            {
               Name = model.Name,
               CreatedAt = model.CreatedDate,
               Machine = model.Machine
            };
        }
    }

    public class AddManufacturalVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MachineId { get; set; }
    }
}
