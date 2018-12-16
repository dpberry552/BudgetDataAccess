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
    public class CategoryTests
    {
        [Test]
        public void CanGetCategoriesByAccountID()
        {
            IEnumerable<Category> categories;
            using(var db = DBConnection.GetConnection())
            {
                categories = Category.GetByAccountID(db,1);
            }
            Assert.That(categories.Count() == 2);
        }
    }
}
