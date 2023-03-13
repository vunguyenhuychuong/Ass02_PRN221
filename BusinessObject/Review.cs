using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class Review
    {
        [Required]
        public string CustomerId { get; set; }

        [Required]
        public string CarId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Rent Price must be number")]
        public int? ReviewStar { get; set; }

        [Required]
        public string Comment { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
