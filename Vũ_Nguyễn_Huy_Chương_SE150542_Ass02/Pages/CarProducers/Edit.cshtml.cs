using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CarProducers
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.CarRentalSystemDBContext _context;

        public EditModel(BusinessObject.CarRentalSystemDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarProducer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarProducerExists(CarProducer.ProducerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarProducerExists(string id)
        {
            return _context.CarProducers.Any(e => e.ProducerId == id);
        }
    }
}
