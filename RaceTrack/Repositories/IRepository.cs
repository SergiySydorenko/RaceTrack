using RaceTrack.Entities;
using RaceTrack.Models;
using System.Collections.Generic;

namespace RaceTrack.Repositories
{
    public interface IRepository
    {
        void AddVehicleOnTrack(Vehicle vehicle);
        Vehicle GetVehicle(VehicleEnum vehicleName);
        List<VehicleOnTrackVM> GetVehiclesOnTrack();
        int GetVehiclesOnTrackCount();
    }
}