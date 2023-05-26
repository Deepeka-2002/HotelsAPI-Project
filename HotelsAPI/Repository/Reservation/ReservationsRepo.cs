using HotelsAPI.Models;
using HotelsAPI.Repository.Hotel;
using HotelsAPI.Repository.Reservation;
using System.Data.Entity;

namespace HotelsAPI.Repository.Reservation
{
    public class ReservationsRepo : IReservationsRepo
    {

            public HotelContext _hotelContext;

            public ReservationsRepo(HotelContext hotelContext)
            {
                _hotelContext = hotelContext;
            }


            public async Task<List<Reservations>> GetReservationDetails()
            {
                var res = await _hotelContext.reservations.ToListAsync();
                return res;
            }

            public async Task<Reservations?> GetReservationDetailById(int id)
            {
                var res = await _hotelContext.reservations.FindAsync(id);
                if (res is null)
                {
                    throw new ArithmeticException("Invalid reservation id");
                }
                return res;
            }

            public async Task<List<Reservations>> AddReservationDetail(Reservations reserve)
            {
                _hotelContext.reservations.Add(reserve);
                await _hotelContext.SaveChangesAsync();
                return await _hotelContext.reservations.ToListAsync();
            }

            public async Task<List<Reservations>?> UpdateReservationDetail(int id, Reservations reserve)
            {
                var res = await _hotelContext.reservations.FindAsync(id);
                if (res is null)
                {
                    throw new ArithmeticException("Invalid reservation id to update details");
                }
            res.CheckInDate = reserve.CheckInDate;
            res.CheckOutDate = reserve.CheckOutDate;
                await _hotelContext.SaveChangesAsync();
                return await _hotelContext.reservations.ToListAsync();
            }

            public async Task<List<Reservations>?> DeleteReservationDetailById(int id)
            {
                var res = await _hotelContext.reservations.FindAsync(id);
                if (res is null)
                {
                    throw new ArithmeticException("Invalid reservation id to delete");

                }
                _hotelContext.Remove(res);
                await _hotelContext.SaveChangesAsync();
                return await _hotelContext.reservations.ToListAsync();
            }
        
    }
}
