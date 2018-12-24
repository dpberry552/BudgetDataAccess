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
    public class SubCategoryTests
    {
        [Test]
        public void CanGetSubCategoriesByCategoryID()
        {
            IEnumerable<SubCategory> subCategories;
            using(var db = DBConnection.GetConnection())
            {
                subCategories = SubCategory.GetByCategoryID(db, 7);
                Assert.That(subCategories.Count() == 2);
            }
        }
    }
}
