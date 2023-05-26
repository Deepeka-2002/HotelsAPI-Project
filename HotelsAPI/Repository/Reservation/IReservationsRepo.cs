using HotelsAPI.Models;

namespace HotelsAPI.Repository.Reservation
{
    public interface IReservationsRepo
    {
        Task<List<Reservations>> GetReservationDetails();
        Task<Reservations?> GetReservationDetailById(int id);
        Task<List<Reservations>> AddReservationDetail(Reservations reserve);
        Task<List<Reservations>?> UpdateReservationDetail(int id, Reservations reserve);
        Task<List<Reservations>?> DeleteReservationDetailById(int id);
    }
}
