using VehicleFleetRegistryAPI.Models;

namespace VehicleFleetRegistryAPI.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles;
        private int _nextId;

        public VehicleRepository()
        {
            _nextId = 0;
            private readonly List<Vehicle> _vehicles =
                [
                    new Vehicle
                    {
                        Id = 1,
                        RegistrationNumber = "TRK-1001",
                        Type = "Truck",
                        Status = VehicleStatus.Available,
                        AssignedDriver = null,
                        CurrentLocation = "Jerusalem Base",
                        Mileage = 45200
                    },

                    new Vehicle
                    {
                        Id = 2,
                        RegistrationNumber = "JEP-2001",
                        Type = "Jeep",
                        Status = VehicleStatus.InUse,
                        AssignedDriver = "David Cohen",
                        CurrentLocation = "Tel Aviv",
                        Mileage = 78100
                    },

                    new Vehicle
                    {
                        Id = 3,
                        RegistrationNumber = "APC-3001",
                        Type = "Armored Personnel Carrier",
                        Status = VehicleStatus.Maintenance,
                        AssignedDriver = null,
                        CurrentLocation = "Maintenance Center",
                        Mileage = 125000
                    },

                    new Vehicle
                    {
                        Id = 4,
                        RegistrationNumber = "TRK-1002",
                        Type = "Truck",
                        Status = VehicleStatus.InUse,
                        AssignedDriver = "Moshe Levi",
                        CurrentLocation = "Haifa",
                        Mileage = 93600
                    },

                    new Vehicle
                    {
                        Id = 5,
                        RegistrationNumber = "JEP-2002",
                        Type = "Jeep",
                        Status = VehicleStatus.Available,
                        AssignedDriver = null,
                        CurrentLocation = "Northern Base",
                        Mileage = 32400
                    },

                    new Vehicle
                    {
                        Id = 6,
                        RegistrationNumber = "APC-3002",
                        Type = "Armored Personnel Carrier",
                        Status = VehicleStatus.Decommissioned,
                        AssignedDriver = null,
                        CurrentLocation = "Storage Facility",
                        Mileage = 248000
                    },

                    new Vehicle
                    {
                        Id = 7,
                        RegistrationNumber = "VAN-4001",
                        Type = "Van",
                        Status = VehicleStatus.Maintenance,
                        AssignedDriver = null,
                        CurrentLocation = "Jerusalem Garage",
                        Mileage = 110500
                    },

                    new Vehicle
                    {
                        Id = 8,
                        RegistrationNumber = "JEP-2003",
                        Type = "Jeep",
                        Status = VehicleStatus.InUse,
                        AssignedDriver = "Yossi Ben David",
                        CurrentLocation = "Beersheba",
                        Mileage = 67400
                    }
                ];



        // method
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public Vehicle? GetById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.Id == id);
        }

        public Vehicle? GetByRegistrationNumber(string regNumber)
        {
            return _vehicles.FirstOrDefault(v => v.RegistrationNumber == regNumber);
        }

        public IEnumerable<Vehicle> GetByStatus(VehicleStatus status)
        {
            return _vehicles.Where(v => v.Status == status);
        }

        public Vehicle Create(Vehicle vehicle)
        {
            vehicle.Id = _nextId;
            _nextId++;

            _vehicles.Add(vehicle);

            return vehicle;
        }

        public Vehicle? Update(int id, Vehicle vehicle)
        {
            var existing = _vehicles.FirstOrDefault(v => v.Id == id);

            if (existing == null)
            {
                return null;
            }

            existing.RegistrationNumber = vehicle.RegistrationNumber;
            existing.VehicleType = vehicle.VehicleType;
            existing.Status = vehicle.Status;
            existing.AssignedDriver = vehicle.AssignedDriver;
            existing.CurrentLocation = vehicle.CurrentLocation;
            existing.Mileage = vehicle.Mileage;

            return existing;
        }

        public bool Delete(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
            {
                return false;
            }

            _vehicles.Remove(vehicle);

            return true;
        }
    }
}
