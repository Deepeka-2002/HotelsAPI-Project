using HotelsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelsAPI.Repository.Customers
{
    public class CustomerRepo: ICustomerRepo
    {
        public HotelContext _hotelContext;
        public CustomerRepo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers =  await _hotelContext.customer.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var customer= await _hotelContext.customer.FindAsync(id);
            if (customer is null)
            {
                throw new ArithmeticException("Invalid Customer id");
            }
            return customer;
        }

        public async Task<List<Customer>> AddCustomer(Customer cust)
        {
            _hotelContext.customer.Add(cust);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.customer.ToListAsync();
        }

        public async Task<List<Customer>?> UpdateCustomer(int id, Customer cust)
        {
            var customer = await _hotelContext.customer.FindAsync(id);
            if (customer is null)
            {
                throw new ArithmeticException("Invalid customer id to update details");
            }
            customer.FirstName = cust.FirstName;
            customer.LastName = cust.LastName;
            customer.Email = cust.Email;
            customer.Address = cust.Address;
            customer.City = cust.City;
            customer.PhoneNumber = cust.PhoneNumber;
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.customer.ToListAsync();
        }

        public async Task<List<Customer>?> DeleteCustomerById(int id)
        {
            var customer = await _hotelContext.customer.FindAsync(id);
            if (customer is null)
            {
                throw new ArithmeticException("Invalid customer id to delete");

            }
            _hotelContext.Remove(customer);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.customer.ToListAsync();
        }

        public IEnumerable<Hotels> SearchHotelLocation(string location)
        {
            try
            {
                var hotelLocation = _hotelContext.hotels.AsQueryable();
                if (!string.IsNullOrEmpty(location))
                {
                    hotelLocation = hotelLocation.Where(l => l.Location == location);
                }
                return hotelLocation;
            }
            catch (Exception ex)
            {
                throw new Exception("No hotels in the particular location!!", ex);
            }
        }

        public IEnumerable<Rooms> RoomPriceLimit(int price)
        {
            try
            {
                var roomPriceFilter = _hotelContext.rooms.AsQueryable();
                roomPriceFilter = roomPriceFilter.Where(r => r.PricePerNight < price);
                return roomPriceFilter;
            }
            catch (Exception ex)
            {
                throw new Exception("No such rooms available in the given price limit", ex);
            }

        }

        public IEnumerable<Rooms> FilterRoomType(string type)
        {
            try
            {
                var roomType = _hotelContext.rooms.AsQueryable();
                roomType = roomType.Where(r => r.RoomType == type);
                return roomType;
            }
            catch (Exception ex)
            {
                throw new Exception("No such rooms available!!", ex);
            }
        }

    }
}
