using Dapper.Contrib.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BudgetDataAccess.Models
{
    [Table("AccountTransaction")]
    public class Transaction : BusinessObject<Transaction>
    {
        public int AccountId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime ActualDateTime { get; set; }
        public DateTime PostDateTime { get; set; }
        [Computed]
        public List<TransactionLine> TransactionLines { get; set; }

        public static IEnumerable<Transaction> GetByAccountId(IDbConnection db, int accountId)
        {
            var tranList = db.Query<Transaction>("select * from AccountTransaction where AccountId = @id", new { id = accountId });

            foreach (var t in tranList)
            {
                t.TransactionLines = Transaction.GetLines(db, t.Id).ToList();
            }

            return tranList;
        }

        public static IEnumerable<TransactionLine> GetLines(IDbConnection db, int transId)
        {
            var lines = db.Query<TransactionLine>("select c.Description as Category, c.Type as CategoryType, r.Amount from TransCatRlship r " +
                                                  "inner join Category c on c.Id = r.CatID " +
                                                  "inner join AccountTransaction t on t.Id = r.TransID " +
                                                  "where r.TransID = @id;", new { id = transId });
            return lines;
        }
    }
}
