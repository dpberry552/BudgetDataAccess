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
    public class TransactionTests
    {
        [Test]
        public void CanPersistTransaction()
        {
            Transaction t = new Transaction
            {
                AccountId = 2,
                Description = "Lowes",
                Type = "Debit",
                Amount = (decimal)72.48,
                ActualDateTime = DateTime.Now,
                PostDateTime = DateTime.Now
            };

            using(var db = DBConnection.GetConnection())
            {
                Transaction.Persist(db, t);
            }
        }

        [Test]
        public void CanGetTransaction()
        {
            using(var db = DBConnection.GetConnection())
            {
                var t = Transaction.GetAll(db).ToList();
                Assert.That(t.Count == 3);
            }
        }

        [Test]
        public void CanGetTransactionLines()
        {
            using(var db = DBConnection.GetConnection())
            {
                var t = Transaction.GetLines(db, 1);
                Assert.That(t.Count() == 2);
                Assert.That(t.First().Amount == 50);
            }
        }
    }
}
