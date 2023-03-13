using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class Customer
    {
        public Customer()
        {
            CarRentals = new HashSet<CarRental>();
            Reviews = new HashSet<Review>();
        }

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string CustomerPassword { get; set; }

        [Required]
        public string IdentityCard { get; set; }

        [Required]
        public string LicenceNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? LicenceDate { get; set; }

        public virtual ICollection<CarRental> CarRentals { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
