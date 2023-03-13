using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccessObject.Repository;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.Cars
{
    public class EditModel : PageModel
    {
        private ICarRepository carRepository;

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(string id)
        {
            carRepository = new CarRepository();


            if (id == null)
            {
                return NotFound();
            }

            Car = carRepository.GetCarID(id);

            if (Car == null)
            {
                return NotFound();
            }
            ViewData["Staff"] = new SelectList(carRepository.GetCarList(), "Staff", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            carRepository = new CarRepository();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRepository.UpdateCar(Car);

            return RedirectToPage("./Index");

        }

      
    }
}
