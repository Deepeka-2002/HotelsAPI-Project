using HotelsAPI.Models;

namespace HotelsAPI.Repository.Hotel
{
    public interface IHotelsRepo
    {
        Task<List<Hotels>> Gethotels();
        Task<Hotels>? GetHotelById (int id);

        Task<List<Hotels>> AddHotel(Hotels hot);
        Task<List<Hotels>?> UpdateHotel(int id, Hotels hot);
        Task<List<Hotels>?> DeleteHotelById(int id);

    }
}
