using Dapper.Contrib.Extensions;
using MiniProfiler.Integrations;
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
                var factory = new SqlServerDbConnectionFactory(db.ConnectionString);
                using (var connection = ProfiledDbConnectionFactory.New(factory, CustomDbProfiler.Current))
                {
                    t.CreateDate = t.UpdateDate;
                    try
                    {
                        db.Insert<T>(t);
                    }
                    catch (Exception)
                    {
                        var commands = CustomDbProfiler.Current.ProfilerContext.GetCommands();
                        Console.WriteLine(commands);
                        throw;
                    }
                }
            }
        }
    }
}
