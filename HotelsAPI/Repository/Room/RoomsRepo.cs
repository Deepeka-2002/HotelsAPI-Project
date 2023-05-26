using HotelsAPI.Models;
using System.Data.Entity;

namespace HotelsAPI.Repository.Room
{
    public class RoomsRepo : IRoomsRepo
    {
        public HotelContext _hotelContext;

        public RoomsRepo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }


        public async Task<List<Rooms>> GetRoomDetails()
        {
            var rooms = await _hotelContext.rooms.ToListAsync();
            return rooms;
        }

        public async Task<Rooms?> GetRoomDetailById(int id)
        {
            var room = await _hotelContext.rooms.FindAsync(id);
            if (room is null)
            {
                throw new ArithmeticException("Invalid room id");
            }
            return room;
        }

        public async Task<List<Rooms>> AddRoomDetail(Rooms room)
        {
            _hotelContext.rooms.Add(room);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.rooms.ToListAsync();
        }

        public async Task<List<Rooms>?> UpdateRoomDetail(int id, Rooms roomm)
        {
            var room = await _hotelContext.rooms.FindAsync(id);
            if (room is null)
            {
                throw new ArithmeticException("Invalid room id to update details");
            }
            room.RoomNumber = roomm.RoomNumber;
            room.RoomType = roomm.RoomType;
            room.PricePerNight = roomm.PricePerNight;
            room.IsAvailable = roomm.IsAvailable;

            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.rooms.ToListAsync();
        }

        public async Task<List<Rooms>?> DeleteRoomDetailById(int id)
        {
            var room = await _hotelContext.rooms.FindAsync(id);
            if (room is null)
            {
                throw new ArithmeticException("Invalid room id to delete");

            }
            _hotelContext.Remove(room);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.rooms.ToListAsync();
        }
    }
}
