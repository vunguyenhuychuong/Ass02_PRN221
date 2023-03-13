using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCarList();
        IEnumerable<Car> SearchCar(String search);
        Car GetCarID(String carID);
        void UpdateCar(Car car);
        void InsertCar(Car car);
        void DeleteCar(Car car);
    }
}
