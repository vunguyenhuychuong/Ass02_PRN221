using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface ICustomerRepository
    {
        Customer LoginByCustomerAccount(String email, String password);
        IEnumerable<Customer> GetCustomerList();
        Customer GetCustomerById(String customerID);
        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IList<CarRental> ViewRentingHistory(String customerID);
    }
}
