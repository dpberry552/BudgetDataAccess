using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace BudgetDataAccess.Models
{
    [Table("Account")]
    public class Account : BusinessObject<Account>
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Institution { get; set; }
        public double Balance { get; set; }

        public static IEnumerable<Account> GetByUserId(IDbConnection db, int userId)
        {
            var accountList = db.Query<Account>(@"select * from Account where UserId = @id", new { id = userId });
            return accountList;
        }
    }

}
