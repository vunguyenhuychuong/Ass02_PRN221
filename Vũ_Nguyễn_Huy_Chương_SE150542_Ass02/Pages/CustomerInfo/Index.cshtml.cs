using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CustomerInfo
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public IndexModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("CustomerId");
            return RedirectToPage("/Login");
        }
    }
}
