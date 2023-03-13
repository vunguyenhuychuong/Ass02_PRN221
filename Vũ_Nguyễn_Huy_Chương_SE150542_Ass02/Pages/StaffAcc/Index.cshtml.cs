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
    public class IndexModel : PageModel
    {
       
        private IStaffAccountRepository staffAccountRepository;

        public IList<StaffAccount> StaffAccount { get;set; }

        public async Task OnGetAsync()
        {
            staffAccountRepository = new StaffAccountRepository();
            StaffAccount = staffAccountRepository.GetStaffAccountList().ToList();
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
