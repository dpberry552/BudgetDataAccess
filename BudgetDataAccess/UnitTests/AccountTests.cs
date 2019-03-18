using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BudgetDataAccess.Connections;
using BudgetDataAccess.Models;

namespace BudgetDataAccess.UnitTests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void CanPersistAccount()
        {
            Account acct = new Account
            {
                Id = 7,
                Description = "Personal Checking",
                Type = "Checking",
                Institution = "Androscoggin Bank",
                Balance = 50.00
            };

            using(var db = DBConnection.GetConnection())
            {
                Account.Persist(db, acct);
            }
        }

        [Test]
        public void CanDeleteAccount()
        {
            Account acct = new Account
            {
                Id = 13,
                Description = "CD",
                Type = "New Savings",
                Institution = "Casco FCU",
                Balance = 250.00
            };

            using (var db = DBConnection.GetConnection())
            {
                Account.Delete(db, 14);
            }
        }
    }
}
