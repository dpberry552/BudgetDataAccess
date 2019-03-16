using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetDataAccess.Models
{
    public class BusinessObject<T>
        where T : BusinessObject<T>
    {
        [Key]
        public int? Id { get; set; }
        [Write(false)]
        public DateTime CreateDate { get; set; }
        [Write(false)]
        public DateTime UpdateDate { get; set; }

        public static BusinessObject<T> GetById(IDbConnection db, int id)
        {
            return db.Get<T>(id);
        }

        public static void Persist(IDbConnection db, T t)
        {
            t.UpdateDate = DateTime.Now;
            if(t.Id != null)
            {
                db.Update<T>(t);
            }
            else
            {
                t.CreateDate = DateTime.Now;
                db.Insert<T>(t);
            }
        }
    }
}
