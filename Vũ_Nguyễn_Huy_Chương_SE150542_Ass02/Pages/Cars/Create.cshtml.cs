using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccessObject.Repository;
using Microsoft.EntityFrameworkCore;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private ICarRepository carRepository;

        public IActionResult OnGet()
        {
            var selectList = new SelectList(new List<String> { "P00001", "P00002", "P00003", "P00004", "P00005" }, "ProducerId");
            ViewData["MySelectList"] = selectList;
            /*ViewData["ProducerId"] = new SelectList(Car.ProducerId, "ProducerId", "ProducerId");*/
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRepository = new CarRepository();
            carRepository.InsertCar(Car);

            return RedirectToPage("./Index");
        }
    }
}
