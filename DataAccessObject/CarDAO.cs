
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();

        private CarDAO() { }

        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Car> GetCars()
        {
            List<Car> cars;
            try
            {
                var context = new CarRentalSystemDBContext();
                cars = context.Cars.Include(c => c.Producer).ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public Car GetCarByID(String carID)
        {
            Car car = null;
            try
            {
                var context = new CarRentalSystemDBContext();
                car = context.Cars.Include(c => c.Producer).SingleOrDefault(c => c.CarId == carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car == null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Update(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Entry<Car>(car).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var context = new CarRentalSystemDBContext();
                    context.Cars.Remove(_car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The car does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public IEnumerable<Car> SearchCar(String search)
        {
            List<Car> cars;
            try
            {
                var context = new CarRentalSystemDBContext();
                cars = context.Cars.Where(c => c.CarName.Contains(search)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cars;
        }
    }
}
