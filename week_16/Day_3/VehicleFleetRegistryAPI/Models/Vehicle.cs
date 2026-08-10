using System.ComponentModel.DataAnnotations;

namespace VehicleFleetRegistryAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string VehicleType { get; set; } = string.Empty;

        [EnumDataType(typeof(VehicleStatus))]
        public VehicleStatus? Status { get; set; }

        [StringLength(100)]
        public string? AssignedDriver { get; set; }

        [StringLength(200)]
        public string? CurrentLocation { get; set; }

        [Range(0, 500000)]
        public int Mileage { get; set; }


    }
}
