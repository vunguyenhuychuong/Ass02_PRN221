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
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public IndexModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IList<CarProducer> CarProducer { get;set; }

        public async Task OnGetAsync()
        {
            CarProducer = await _context.CarProducers.ToListAsync();
        }
    }
}
