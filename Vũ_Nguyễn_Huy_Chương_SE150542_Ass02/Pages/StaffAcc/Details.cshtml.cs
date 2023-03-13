using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using DataAccessObject.Repository;

namespace Vũ_Nguyễn_Huy_Chương_SE150542_Ass02.Pages.StaffAcc
{
    public class DetailsModel : PageModel
    {
        private IStaffAccountRepository staffAccountRepository;

        [BindProperty]
        public StaffAccount StaffAccount { get; set; }

        public IActionResult OnGet(string id)
        {
            staffAccountRepository= new StaffAccountRepository();

            if(id == null)
            {
                return NotFound();
            }

           StaffAccount = staffAccountRepository.GetSatffAccountByID(id);

            if(StaffAccount == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
