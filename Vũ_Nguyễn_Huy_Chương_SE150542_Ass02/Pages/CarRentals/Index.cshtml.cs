using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccessObject.Repository;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CarRentals
{
    public class IndexModel : PageModel
    {
        private ICarRentalRepository carRentalRepository;

        public IList<CarRental> CarRentals { get; set; }

        public void OnGet()
        {
            carRentalRepository = new CarRentalRepository();
            CarRentals = carRentalRepository.GetCarRentalList();
        }



        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("StaffId");
            return RedirectToPage("/Login");
        }
    }
}
