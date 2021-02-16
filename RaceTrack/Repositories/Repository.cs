using Microsoft.EntityFrameworkCore;
using RaceTrack.Controllers;
using RaceTrack.Entities;
using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTrack.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vehicle GetVehicle(VehicleEnum vehicleName)
        {
            var vehicle = _dbContext.Vehicles.Where(x => x.Id == (int)vehicleName).FirstOrDefault();
            return vehicle;
        }

        //idealy need to handle exceptions and show user in case of error during saving
        public void AddVehicleOnTrack(Vehicle vehicle)
        {
            var vehicleOnTrack = new VehiclesOnTrack() { Vehicle = vehicle };
            _dbContext.VehiclesOnTrack.Add(vehicleOnTrack);
            _dbContext.SaveChanges();
        }

        public int GetVehiclesOnTrackCount()
        {
            return _dbContext.VehiclesOnTrack.Count();
        }

        public List<VehicleOnTrackVM> GetVehiclesOnTrack()
        {
            IQueryable<VehiclesOnTrack> vehiclesOnTrack = _dbContext.VehiclesOnTrack.Include(x => x.Vehicle);
            var vehiclesOnTrackVM = vehiclesOnTrack.Select(x => new VehicleOnTrackVM { Id = x.Id, Name = x.Vehicle.Name }).ToList();
            return vehiclesOnTrackVM;
        }

    }
}
