using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class StaffAccountRepository : IStaffAccountRepository
    {
        public void DeleteStaffAccount(StaffAccount staffAccount)
        {
            StaffAccountDAO.Instance.Remove(staffAccount);
        }

        public StaffAccount GetSatffAccountByID(String staffID)
        {
            return StaffAccountDAO.Instance.GetSatffAccountByID(staffID);
        }

        public StaffAccount GetStaffAccountByEmail(string email)
        {
            return StaffAccountDAO.Instance.GetStaffAccountByEmail(email);
        }

        public IEnumerable<StaffAccount> GetStaffAccountList()
        {
            return StaffAccountDAO.Instance.GetStaffAccountList();
        }

        public void InsertStaffAccount(StaffAccount staffAccount)
        {
            StaffAccountDAO.Instance.AddNew(staffAccount);
        }

        public StaffAccount LoginByStaffAccount(string email, string password)
        {
            return StaffAccountDAO.Instance.LoginByStaffAccount(email, password);
        }

        public IEnumerable<StaffAccount> SearchStaffAccount(string search)
        {
            return StaffAccountDAO.Instance.SearchStaffAccount(search);
        }

        public void UpdateStaffAccount(StaffAccount staffAccount)
        {
            StaffAccountDAO.Instance.Update(staffAccount);
        }
    }
}
