using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceTrack.Entities;
using RaceTrack.Models;
using RaceTrack.Repositories;

namespace RaceTrack.Controllers
{
    public class AddVehicleOnTrackController : Controller
    {
        private readonly IRepository _repository;
        public AddVehicleOnTrackController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }       

        [HttpPost]
        public JsonResult Add(string vehicleStr)
        {         

            var quantityOnTrack = _repository.GetVehiclesOnTrackCount();
            Vehicle vehicle=null;
            if (quantityOnTrack == 5)
                 return Json($"nok");

            if (vehicleStr == "car")
                vehicle = _repository.GetVehicle(VehicleEnum.Car);
            else if (vehicleStr == "truck")
                vehicle = _repository.GetVehicle(VehicleEnum.Truck);

            if (vehicle ==null)
                return Json($"error");

            _repository.AddVehicleOnTrack(vehicle);
            return  Json($"ok"); 
        }
    }
}