using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(Car car)
        {
            CarDAO.Instance.Remove(car);
        }

        public Car GetCarID(string carID)
        {
            return CarDAO.Instance.GetCarByID(carID);
        }

        public IEnumerable<Car> GetCarList()
        {
            return CarDAO.Instance.GetCars();
        }

        public void InsertCar(Car car)
        {
            CarDAO.Instance.AddNew(car);
        }

        public IEnumerable<Car> SearchCar(string search)
        {
            return CarDAO.Instance.SearchCar(search);
        }

        public void UpdateCar(Car car)
        {
            CarDAO.Instance.Update(car);
        }
    }
}
