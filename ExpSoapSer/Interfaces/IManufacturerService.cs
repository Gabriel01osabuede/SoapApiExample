using ExpSoapSer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpSoapSer.Interfaces
{
    public interface IManufacturerService
    {
        string AddManufacturer(AddManufacturalVM model);
        List<ManufacturalVM> RetrieveAllManufacturerData();
        string EditManufacturerData(int Id,AddManufacturalVM model);
        string RemoveManufactrer(int Id);
        ManufacturalVM GetSingleManufactrer(int Id);
    }
}