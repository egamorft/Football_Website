using BusinessObject;
using DataAccess.DAO;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implements
{
    public class AccountRepository : IAccountRepository
    {
        public void CreateAccount(Account account)
        {
            AccountDAO.CreateAccount(account);
        }

        public void DeleteAccount(Account account)
        {
            AccountDAO.DeleteAccount(account);
        }

        public Account GetAccountById(int id)
        {
            return AccountDAO.GetAccountById(id);
        }

        public List<Account> GetAccounts()
        {
            return AccountDAO.GetAccounts();
        }

        public void UpdateAccount(Account account)
        {
            AccountDAO.UpdateAccount(account);
        }
    }
}
