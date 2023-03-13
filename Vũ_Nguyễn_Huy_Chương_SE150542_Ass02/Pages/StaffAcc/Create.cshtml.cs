using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using DataAccessObject.Repository;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.StaffAcc
{
    public class CreateModel : PageModel
    {
        private IStaffAccountRepository staffAccountRepository;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            staffAccountRepository= new StaffAccountRepository();
            staffAccountRepository.InsertStaffAccount(StaffAccount);

            return RedirectToPage("./Index");
        }
    }
}
