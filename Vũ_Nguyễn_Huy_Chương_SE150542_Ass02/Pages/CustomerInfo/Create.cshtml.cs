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

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CustomerInfo
{
    public class CreateModel : PageModel
    {
        private ICarRentalRepository carRentalRepository;

        private ICustomerRepository customerRepository;

        private ICarRepository carRepository;

        public IActionResult OnGet()
        {
            carRepository= new CarRepository();
            customerRepository = new CustomerRepository();
            carRentalRepository = new CarRentalRepository();

            ViewData["CustomerId"] = new SelectList(customerRepository.GetCustomerList(), "CustomerId", "Begin");
            ViewData["CarId"] = new SelectList(carRepository.GetCarList(), "CarId", "Last");

           return Page();
        }

        [BindProperty]
        public CarRental CarRentals { get; set; }

        [BindProperty]
        public Customer Customers { get; set; }

        [BindProperty]
        public Car Cars { get; set; }   

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            carRentalRepository = new CarRentalRepository();

            carRentalRepository.AddCarRental(CarRentals);

            return RedirectToPage("./Index");
        }
    }
}
