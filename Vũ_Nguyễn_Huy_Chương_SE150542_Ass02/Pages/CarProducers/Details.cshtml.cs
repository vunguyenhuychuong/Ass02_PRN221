using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CarProducers
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public DetailsModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public CarProducer CarProducer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarProducer = await _context.CarProducers.FirstOrDefaultAsync(m => m.ProducerId == id);

            if (CarProducer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
