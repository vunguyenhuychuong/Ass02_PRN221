using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class CarRentalRepository : ICarRentalRepository
    {
        public void AddCarRental(CarRental carRental)
        {
            CarRentalDAO.Instance.AddNew(carRental);
        }

        public CarRental CheckCarRentalBetweenDate(CarRental carRental)
        {
            return CarRentalDAO.Instance.CheckCarRentalBetweenDate(carRental);
        }

        public IList<CarRental> GetCarRentalList()
        {
            return CarRentalDAO.Instance.GetCarRentals();
        }
    }
}
