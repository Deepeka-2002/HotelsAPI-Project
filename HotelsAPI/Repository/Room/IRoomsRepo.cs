using HotelsAPI.Models;

namespace HotelsAPI.Repository.Room
{
    public interface IRoomsRepo
    {
        Task<List<Rooms>> GetRoomDetails();
        Task<Rooms?> GetRoomDetailById(int id);
        Task<List<Rooms>> AddRoomDetail(Rooms room);
        Task<List<Rooms>?> UpdateRoomDetail(int id, Rooms roomm);
        Task<List<Rooms>?> DeleteRoomDetailById(int id);
    }
}
