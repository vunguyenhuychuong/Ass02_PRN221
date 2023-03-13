using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObject
{
    public partial class StaffAccount
    {
        [Required]
        public string StaffId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 6)]
        public string FullName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        public int? Role { get; set; }
    }
}
