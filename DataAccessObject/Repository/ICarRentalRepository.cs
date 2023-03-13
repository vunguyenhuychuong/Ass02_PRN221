using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface ICarRentalRepository
    {
        IList<CarRental> GetCarRentalList();
        void AddCarRental(CarRental carRental);
        CarRental CheckCarRentalBetweenDate(CarRental carRental);
    }
}
