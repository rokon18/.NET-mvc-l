using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NewsRepo : INewsRepo
    {
        NEWSContext db;
        public NewsRepo()
        {
            db = new NEWSContext();
        }

      

        public List<News> Get()
        {
            return db.Newses.ToList();
        }

        public News Get(int id)
        {
           return db.Newses.Find(id);
        }

        public News Get(DateTime date, Category cname)
        {
            throw new NotImplementedException();
        }

        public News Get(Category cname)
        {
            throw new NotImplementedException();
        }

        public News Get(DateTime date)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            var news = Get(id);
            if (news == null)
            {
                return false;
            }
            db.Newses.Remove(news);
            return db.SaveChanges() > 0;

        }
        public bool Update(News n)
        {
            
                var exobj = Get(n.Id);

                db.Entry(exobj).CurrentValues.SetValues(n);
                return db.SaveChanges() > 0;
            
        }
    }
}
