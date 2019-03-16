using Dapper.Contrib.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    [Table("CheckDetail")]
    public class CheckDetail : BusinessObject<CheckDetail>
    {
        public int TransID { get; set; }
        public int Number { get; set; }
        public string PayTo { get; set; }
        public DateTime CheckDate { get; set; }

        public static IEnumerable<CheckDetail> GetByTransID(IDbConnection db, int transID)
        {
            var checkDetailList = db.Query<CheckDetail>("select * from CheckDetail where TransID = @id", new { id = transID });
            return checkDetailList;
        }
    }
}
