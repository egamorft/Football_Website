using BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        public static List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    listAccounts = context.Accounts.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listAccounts;
        }
        public static Account GetAccountById(int id)
        {
            Account a = new Account();
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    a = context.Accounts.SingleOrDefault(x => x.AccountId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return a;
        }
        public static void CreateAccount(Account a)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Accounts.Add(a);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateAccount(Account a)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    context.Entry<Account>(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteAccount(Account a)
        {
            try
            {
                using (var context = new ProjectPRN231Context())
                {
                    var a1 = context.Accounts.SingleOrDefault(x => x.AccountId == a.AccountId);
                    context.Accounts.Remove(a1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
