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
    public class CheckDetailTests
    {
        [Test]
        public void CanGetCheckDetailByTransID()
        {
            IEnumerable<CheckDetail> checkDetails;
            using(var db = DBConnection.GetConnection())
            {
                checkDetails = CheckDetail.GetByTransID(db, 1);
                Assert.That(checkDetails.Count() == 1);
            }
        }
    }
}
