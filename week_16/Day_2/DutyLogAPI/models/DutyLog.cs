using System.ComponentModel.DataAnnotations;

namespace DutyLogAPI.Models
{
    public class DutyLog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "DutyPersonName is required.")]
        public string DutyPersonName { get; set; } = string.Empty;

        [Required(ErrorMessage = "StationName is required.")]
        public string StationName { get; set; } = string.Empty;

        [Range(1, 20, ErrorMessage = "StationNumber must be between 1 and 20.")]
        public int StationNumber { get; set; }

        [Required(ErrorMessage = "ShiftStart is required.")]
        public DateTime? ShiftStart { get; set; }

        [Required(ErrorMessage = "ShiftEnd is required.")]
        public DateTime? ShiftEnd { get; set; }

        [StringLength(200, ErrorMessage = "Remarks must be less than 200 characters.")]
        public string Remarks { get; set; } = string.Empty;
    }
}