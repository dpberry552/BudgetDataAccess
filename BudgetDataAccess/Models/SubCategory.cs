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
    [Table("SubCategory")]
    public class SubCategory : BusinessObject<SubCategory>
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }

        public static IEnumerable<SubCategory> GetByCategoryID(IDbConnection db, int categoryID)
        {
            var subCategoryList = db.Query<SubCategory>("select * from SubCategory where CategoryID = @id", new { id = categoryID});
            return subCategoryList;
        }
    }
}
