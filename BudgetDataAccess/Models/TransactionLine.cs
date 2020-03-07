using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    public class TransactionLine
    {
        public string Category { get; set; }
        public string CategoryType { get; set; }
        public decimal Amount { get; set; }
    }
}
