using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface IStaffAccountRepository
    {   
        IEnumerable<StaffAccount> GetStaffAccountList();
        IEnumerable<StaffAccount> SearchStaffAccount(String search);
        StaffAccount GetSatffAccountByID(String staffID);
        void UpdateStaffAccount(StaffAccount staffAccount);
        void InsertStaffAccount(StaffAccount staffAccount);
        void DeleteStaffAccount(StaffAccount staffAccount);
        StaffAccount GetStaffAccountByEmail(string email);

        StaffAccount LoginByStaffAccount(String email, String password);
    }
}
