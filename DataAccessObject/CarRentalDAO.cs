using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CarRentalDAO
    {
        private static CarRentalDAO instance = null;
        private static readonly object instanceLock = new object();

        private CarRentalDAO() { }

        public static CarRentalDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarRentalDAO();
                    }
                    return instance;
                }
            }
        }

        public IList<CarRental> GetCarRentals()
        {
            List<CarRental> carRentals;
            try
            {
                var context = new CarRentalSystemDBContext();
                carRentals = context.CarRentals.Include(c => c.Car).Include(c => c.Customer).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carRentals;
        }

        public void AddNew(CarRental carRental)
        {
            try
            {
                var context = new CarRentalSystemDBContext();
                context.CarRentals.Add(carRental);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public CarRental CheckCarRentalBetweenDate(CarRental carRental)
        {
            CarRental rental;
            try
            {
                var context = new CarRentalSystemDBContext();
                rental = context.CarRentals.FirstOrDefault(c => (c.PickupDate <= carRental.PickupDate && carRental.PickupDate <= c.ReturnDate)
                        || (c.PickupDate <= carRental.ReturnDate && carRental.ReturnDate <= c.ReturnDate)
                        && c.CarId == carRental.CarId);

                return rental;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
