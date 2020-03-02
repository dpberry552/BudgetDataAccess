using Dapper.Contrib.Extensions;
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
    }
}
