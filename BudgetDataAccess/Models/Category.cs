using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    [Table("Category")]
    public class Category : BusinessObject<Category>
    {
        public int AccountID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }

        public static IEnumerable<Category> GetByAccountID(IDbConnection db, int accountID)
        {
            var categoryList = db.Query<Category>(@"select * from Category where AccountID = @id", new { id = accountID });
            return categoryList;
        }
    }
}
