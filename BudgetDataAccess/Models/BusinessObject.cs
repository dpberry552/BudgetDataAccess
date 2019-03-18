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
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public static BusinessObject<T> GetById(IDbConnection db, int id)
        {
            return db.Get<T>(id);
        }

        public static IEnumerable<BusinessObject<T>> GetAll(IDbConnection db)
        {
            return db.GetAll<T>();
        }

        public static void Delete(IDbConnection db, int id)
        {
            T obj = db.Get<T>(id);
            db.Delete<T>(obj);
        }

        public static void Persist(IDbConnection db, T t)
        {
            t.UpdateDate = DateTime.Now;
            if (t.Id != 0)
            {
                db.Update<T>(t);
            }
            else
            {
                t.CreateDate = t.UpdateDate;
                db.Insert<T>(t);
            }
        }
    }
}
