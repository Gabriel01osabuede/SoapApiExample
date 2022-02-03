using ExpSoapSer.Context;
using ExpSoapSer.Interfaces;
using ExpSoapSer.Models;
using ExpSoapSer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpSoapSer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly ApplicationDbContext _context;

        public ManufacturerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddManufacturer(AddManufacturalVM model)
        {
            if (model == null)
                return "All fields are required!!";

            var data = new ManufacturalModel {
                Id = model.Id,
                Name = model.Name,
                MachineId = model.MachineId,
                CreatedDate = model.CreatedAt
            };

            _context.ManufacturalModels.Add(data);
            _context.SaveChanges();


            return "Manufacturer Added Successfully!!";

        }

        public string EditManufacturerData(int Id,AddManufacturalVM model)
        {
            var getAllManufacturer = _context.ManufacturalModels.ToList();
            var result = getAllManufacturer.Where(x => x.Id == Id).FirstOrDefault();
            var editedData = new ManufacturalModel {

                Name = model.Name,
                CreatedDate = model.CreatedAt,
                MachineId = model.MachineId,
            };
            _context.Update(editedData);
            _context.SaveChanges();

            return " Data Updated Successfully";
        }

        public ManufacturalVM GetSingleManufactrer(int Id)
        {
            var getAllManufacturer = _context.ManufacturalModels.ToList();
            var result = getAllManufacturer.Where(x => x.Id == Id).Select(x => new ManufacturalVM()).FirstOrDefault();

            return result;
        }

        public string RemoveManufactrer(int Id)
        {
            var getAllManufacturer = _context.ManufacturalModels.ToList();
            var userData = getAllManufacturer.Find(x => x.Id == Id);

            var removeData = _context.Remove(userData);
            
            _context.SaveChanges();
            
            return "Manufacturer Deleted Successfully";
            
        }

        public List<ManufacturalVM> RetrieveAllManufacturerData()
        {
            var result = new List<ManufacturalVM>();
            var manufacturers = _context.ManufacturalModels.ToList();
            foreach (var Manufacturer in manufacturers)
            {
                var Data = new ManufacturalVM()
                {
                    Name = Manufacturer.Name,
                    CreatedAt = Manufacturer.CreatedDate,
                    Machine = Manufacturer.Machine
                };

                result.Add(Data);
            }

            return result;
        }

    }
}
