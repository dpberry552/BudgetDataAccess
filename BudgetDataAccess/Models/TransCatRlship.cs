using Dapper.Contrib.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    [Table("TransCatRlship")]
    public class TransCatRlship : BusinessObject
    {
        public int TransID { get; set; }
        public int CatID { get; set; }
        public int SubCatID { get; set; }
        public decimal Amount { get; set; }
    }
}
