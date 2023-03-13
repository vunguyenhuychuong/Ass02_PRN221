using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();

        private CustomerDAO() { }

        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        public Customer LoginByCustomerAccount(String email, String password)
        {
            Customer customer = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                customer = context.Customers.SingleOrDefault(c => c.CustomerEmail == email && c.CustomerPassword == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public IEnumerable<Customer> GetCustomerList()
        {
            List<Customer> customers;
            try
            {
                var context = new CarRentalSystemDBContext();
                customers = context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public Customer GetCustomerById(String customerID)
        {
            Customer customer = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                customer = context.Customers.SingleOrDefault(c => c.CustomerId == customerID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public void Update(Customer customer)
        {
            try
            {
                Customer _customer = GetCustomerById(customer.CustomerId);
                if (_customer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Entry<Customer>(customer).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void AddNew(Customer customer)
        {
            try
            {
                Customer _customer = GetCustomerById(customer.CustomerId);
                if (_customer == null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IList<CarRental> ViewRentingHistory(String customerID)
        {
            List<CarRental> listCarRental;
            try

            {
                var context = new CarRentalSystemDBContext();
                listCarRental = context.CarRentals.Where(c => c.CustomerId.Contains(customerID))
                    .Include(x => x.Car).Include(x => x.Customer).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCarRental;
        }

        public void Remove(Customer customer)
        {
            try
            {
                Customer _customer = GetCustomerById(customer.CustomerId);
                if (_customer != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Customers.Remove(_customer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The staff account does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

