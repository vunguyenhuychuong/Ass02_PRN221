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
using Microsoft.AspNetCore.Http;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.StaffAcc
{
    public class EditModel : PageModel
    {
        private IStaffAccountRepository staffAccountRepository;

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        public IActionResult OnGet(string id)
        {
            staffAccountRepository = new StaffAccountRepository();


            if (id == null)
            {
                return NotFound();
            }

            StaffAccount = staffAccountRepository.GetSatffAccountByID(id);

            if (StaffAccount == null)
            {
                return NotFound();
            }
            ViewData["Staff"] = new SelectList(staffAccountRepository.GetStaffAccountList(), "Staff", "Title");
            return Page();
        }

        public IActionResult OnPost()
        {
            staffAccountRepository = new StaffAccountRepository();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            staffAccountRepository.UpdateStaffAccount(StaffAccount);

            return RedirectToPage("./Index");

        }

    }
}
