using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

#nullable disable

namespace BusinessObject
{
    public partial class Car
    {
        public Car()
        {
            CarRentals = new HashSet<CarRental>();
            Reviews = new HashSet<Review>();
        }

        [Required]
        public string CarId { get; set; }

        
        [Required]
        [StringLength(30, MinimumLength = 6)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Car Name must be string")]
        public string CarName { get; set; }

        [Required]
        public int? CarModelYear { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Range(1, 100), DataType(DataType.Currency)]
        public int? Capacity { get; set; }
        public string Description { get; set; }

        [Required]     
        [DataType(DataType.Date)]
        public DateTime? ImportDate { get; set; }

        [Required]
        public decimal? RentPrice { get; set; }

        [Required]
        public int? Status { get; set; }

        
        public string ProducerId { get; set; }

        public virtual CarProducer Producer { get; set; }
        public virtual ICollection<CarRental> CarRentals { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
