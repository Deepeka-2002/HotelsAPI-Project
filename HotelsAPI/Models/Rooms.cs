using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelsAPI.Models
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }

        public string? RoomType { get; set; }

        public int RoomNumber { get; set; }

        public int PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        //Foreign key
        public int HotelId { get; set; }
        public Hotels? hotels { get; set; }
        
        //Navigation
        public ICollection<Reservations>? reservations { get; set; }
    }
}
