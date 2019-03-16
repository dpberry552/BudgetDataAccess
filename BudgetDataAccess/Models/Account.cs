using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BudgetDataAccess.Models
{
    [Table("Account")]
    public class Account : BusinessObject<Account>
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string Institution { get; set; }
        public decimal Balance { get; set; }
    }
}
