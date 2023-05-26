using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelsAPI.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationId { get; set; } 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
         
        // Foreign key
        public int CustomerId { get; set; } 
        public Customer? customer { get; set; }
        public int RoomId { get; set; } 
        public Rooms? rooms { get; set; }
    }
}
