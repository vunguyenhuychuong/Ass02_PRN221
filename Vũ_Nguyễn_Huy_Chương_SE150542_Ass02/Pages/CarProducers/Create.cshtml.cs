using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CarProducers
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public CreateModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarProducer CarProducer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarProducers.Add(CarProducer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
