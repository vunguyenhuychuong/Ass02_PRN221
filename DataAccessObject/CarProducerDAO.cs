using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CarProducerDAO
    {
        private static CarProducerDAO instance = null;
        private static readonly object instanceLock = new object();

        private CarProducerDAO() { }

        public static CarProducerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarProducerDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<CarProducer> GetCarProducers()
        {
            List<CarProducer> carProducers;
            try
            {
                var context = new CarRentalSystemDBContext();
                carProducers = context.CarProducers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return carProducers;
        }
    }
}
