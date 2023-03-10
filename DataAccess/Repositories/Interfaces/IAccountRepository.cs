using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);
        Account GetAccountById(int id);
        List<Account> GetAccounts();
        void DeleteAccount(Account account);
        void UpdateAccount(Account account);
    }
}
