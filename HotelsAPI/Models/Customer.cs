using System.ComponentModel.DataAnnotations;

namespace HotelsAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;    

        public string? Email { get; set; }
        public long PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        //Navigation
        public ICollection<Reservations>? reservations { get; set; }
    }
}
