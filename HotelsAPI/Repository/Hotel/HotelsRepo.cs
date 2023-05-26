using HotelsAPI.Models;
using Microsoft.CodeAnalysis;
using System.Data.Entity;

namespace HotelsAPI.Repository.Hotel
{ 
    public class HotelsRepo : IHotelsRepo
    {
        
        public HotelContext _hotelContext;
        private object hotelLocation;

        public HotelsRepo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }


        public async Task<List<Hotels>> Gethotels()
        {
            var hotels = await _hotelContext.hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotels?> GetHotelById(int id)
        {
            var hotel = await _hotelContext.hotels.FindAsync(id);
            if(hotel is null)
            {
                throw new ArithmeticException("Invalid Hotel id");
            }
            return hotel;
        }

        public async Task<List<Hotels>> AddHotel(Hotels hot)
        {
            _hotelContext.hotels.Add(hot);
            await _hotelContext.SaveChangesAsync(); 
            return await _hotelContext.hotels.ToListAsync() ;
        }

        public async Task<List<Hotels>?> UpdateHotel(int id, Hotels hot)    
        {
            var hotel = await _hotelContext.hotels.FindAsync(id);
            if(hotel is null )
            {
                throw new ArithmeticException("Invalid hotel id to update details");
            }
            hotel.HotelName = hot.HotelName;
            hotel.CreationYear = hot.CreationYear;
            hotel.PricePerDay = hot.PricePerDay;
            hotel.UpdateRooms = hot.UpdateRooms;
            hotel.Location = hot.Location;
            await _hotelContext.SaveChangesAsync() ;
            return await _hotelContext.hotels.ToListAsync();
        }

        public async Task<List<Hotels>?> DeleteHotelById(int id)
        {
            var hotel = await _hotelContext.hotels.FindAsync(id);
            if( hotel is null )
            {
                throw new ArithmeticException("Invalid hotel id to delete");
            }
            _hotelContext.Remove(hotel);
            await _hotelContext.SaveChangesAsync() ;
            return await _hotelContext.hotels.ToListAsync() ;
        }
 
    }
}
