using BusinessObject;
using DataAccessObject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages
{
    public class RegisterModel : PageModel
    {
        private ICustomerRepository customerRepository;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            

            customerRepository = new CustomerRepository();
            customerRepository.AddCustomer(Customer);

            return RedirectToPage("./Login");
        }
    }
}
