using System.ComponentModel.DataAnnotations;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Customer Name")]
        public required string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter customer type (Business/Personal)")]
        [Display(Name = "Customer Type: Business/Personal")]
        public required string CustomerType { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public required string CustomerAddress { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public required string CustomerEmail { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public required string PhoneNumber { get; set; } 
    }
}
