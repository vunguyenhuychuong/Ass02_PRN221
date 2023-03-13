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

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.CustomerInfo
{
    public class EditModel : PageModel
    {
        private ICustomerRepository customerRepository;

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet(string id)
        {
            customerRepository = new CustomerRepository();


            if (id == null)
            {
                return NotFound();
            }

            Customer = customerRepository.GetCustomerById(id);

            if (Customer == null)
            {
                return NotFound();
            }
            ViewData["Customer"] = new SelectList(customerRepository.GetCustomerList(), "Customer", "Title");
            return Page();
        }

        public IActionResult OnPost()
        {
            customerRepository = new CustomerRepository();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            customerRepository.UpdateCustomer(Customer);

            return RedirectToPage("./Index");

        }
    }
}
