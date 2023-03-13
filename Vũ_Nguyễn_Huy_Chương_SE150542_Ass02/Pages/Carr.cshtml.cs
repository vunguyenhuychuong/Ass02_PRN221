using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages
{
    public class CarrModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public CarrModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IList<CarRental> CarRental { get;set; }

        public async Task OnGetAsync()
        {
            CarRental = await _context.CarRentals
                .Include(c => c.Car)
                .Include(c => c.Customer).ToListAsync();
        }
    }
}
