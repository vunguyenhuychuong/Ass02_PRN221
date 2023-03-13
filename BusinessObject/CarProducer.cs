using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class CarProducer
    {
        public CarProducer()
        {
            Cars = new HashSet<Car>();
        }

        public enum CarProducerId
        {
            P00001, P00002, P00003, P00004, P00005
        }

        public string ProducerId { get; set; }
        public string ProcuderName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
