using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    public class BusinessObject
    {
        [Key]
        public int ID { get; set; }
    }
}
