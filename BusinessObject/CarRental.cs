using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class CarRental
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string CarId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [Required]
        public decimal? RentPrice { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
