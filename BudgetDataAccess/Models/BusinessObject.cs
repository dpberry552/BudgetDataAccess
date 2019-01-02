using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    public class BusinessObject
    {
        [Key]
        public int ID { get; set; }

        public static T GetById<T>(IDbConnection db, int id)
            where T : BusinessObject
        {
            return db.Get<T>(id);
        }

        public static void Persist<T>(IDbConnection db, T t)
        {
            //TODO
        }
    }
}
