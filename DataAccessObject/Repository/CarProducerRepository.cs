using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class CarProducerRepository : ICarProducerRepository
    {
        public IEnumerable<CarProducer> GetCarProducerList()
        {
            return CarProducerDAO.Instance.GetCarProducers();
        }
    }
}
