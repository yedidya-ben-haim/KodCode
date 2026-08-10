using VehicleFleetRegistryAPI.Models;

namespace VehicleFleetRegistryAPI.Repository
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle? GetById(int id);
        Vehicle? GetByRegistrationNumber(string regNumber);
        IEnumerable<Vehicle> GetByStatus(VehicleStatus status);
        Vehicle Create(Vehicle vehicle);
        Vehicle? Update(int id, Vehicle vehicle);
        bool Delete(int id);
    }
}
