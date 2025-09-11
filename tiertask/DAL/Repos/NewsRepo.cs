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
            var news = (from n in db.Newses
                            where n.Date == date && n.ctg.Id == cname.Id
                            select n).FirstOrDefault();
            return news;

        }

        public News Get(Category cname)
        {
            return (from n in db.Newses
                    where n.ctg.Id == cname.Id
                    select n).FirstOrDefault();

        }

        public News Get(DateTime date)
        {
            
            return db.Newses.Find(date);
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
