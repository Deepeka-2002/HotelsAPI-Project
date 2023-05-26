using HotelsAPI.Models;

namespace HotelsAPI.Repository.Customers
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer>? GetCustomerById(int id);

        Task<List<Customer>> AddCustomer(Customer cust);
        Task<List<Customer>?> UpdateCustomer(int id, Customer cust);
        Task<List<Customer>?> DeleteCustomerById(int id);
        IEnumerable<Hotels> SearchHotelLocation(string location);
        IEnumerable<Rooms> RoomPriceLimit(int price);

        IEnumerable<Rooms> FilterRoomType(string type);
    }
}
