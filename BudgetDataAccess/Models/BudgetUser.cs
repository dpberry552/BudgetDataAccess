using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BudgetDataAccess.Models
{
    [Table("BudgetUser")]
    public class BudgetUser : BusinessObject<BudgetUser>
    {
        public string UserName { get; set; }
        //For prototype, passwords are plain text. Obviously, I will change this.
        public string Password { get; set; }

        public static BudgetUser GetByUserName(IDbConnection db, string username)
        {
            string sql = "select * from BudgetUser where UserName = @un";
            var user = db.Query<BudgetUser>(sql, new { un = username }).FirstOrDefault();
            return user;
        }
    }
}
