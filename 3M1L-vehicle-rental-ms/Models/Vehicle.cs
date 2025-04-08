using System.ComponentModel.DataAnnotations;
namespace _3M1L_vehicle_rental_ms.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [Display(Name = "Manufacturer")]
        public string VehicleManufacturer { get; set; } = "";

        [Required(ErrorMessage = "Model is required")]
        [Display(Name = "Model")]
        public string VehicleModel { get; set; } = "";

        [Required(ErrorMessage = "Year is required")]
        [Display(Name = "Year")]
        public int VehicleYear { get; set; }

        [Display(Name = "Availability")]
        public bool VehicleAvailability { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public string VehicleStatus { get; set; } = "";
    }
}