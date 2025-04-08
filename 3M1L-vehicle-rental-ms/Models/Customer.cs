using System.ComponentModel.DataAnnotations;
namespace _3M1L_vehicle_rental_ms.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JokeQuestion { get; set; } = "";
        [Required]
        public string JokeAnswer { get; set; } = "";
    }
}
