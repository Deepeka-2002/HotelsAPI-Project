using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelsAPI.Models
{
    public class Hotels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   
        public int HotelId { get; set; }
        public string? HotelName { get; set;}
        public string? Location { get; set;}
        public int PricePerDay { get; set;}
        public int CreationYear { get; set;} 
        public int UpdateRooms{ get; set;}

        //Navigation
        public ICollection <Rooms>? rooms { get; set; }

    }
}
