using System.ComponentModel.DataAnnotations;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
    
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = " Administrator Name")]
        public string AdminName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Administrator Email")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Password requiered")]
        [DataType(DataType.Password)]
        [Display(Name = "Administrator Password")]
        private string _adminPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string AdminPhoneNumber { get; set; }
    }
}
