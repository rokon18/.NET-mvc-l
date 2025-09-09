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
    internal class CategoryRepo : ICategoryRepo
    {
        NEWSContext db;
        public CategoryRepo()
        {
            db = new NEWSContext();
        }
        public bool Delete(int id)
        {
            return true;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category c)
        {
            var exobj = Get(c.Id);

            db.Entry(exobj).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        
    }
}
