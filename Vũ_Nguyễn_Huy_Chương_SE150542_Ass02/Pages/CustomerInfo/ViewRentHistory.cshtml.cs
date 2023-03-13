using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccessObject.Repository;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CustomerInfo
{
    public class ViewRentHistoryModel : PageModel
    {
        private ICustomerRepository customerRepository;

        public IList<CarRental> CarRental { get; set; }

        public IActionResult OnGet(string id)
        {
            customerRepository = new CustomerRepository();
            if (id == null)
            {
                return NotFound();
            }

            CarRental = customerRepository.ViewRentingHistory(id);

            if (CarRental == null)
            {
                return NotFound();
            }

            return Page();
        }       
    }
}
