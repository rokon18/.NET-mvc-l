using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INewsRepo
    {
       
           
        List<News> Get();
        News Get(int id);
        News Get(DateTime date);
        News Get(DateTime date, Category cname);
        News Get( Category cname);
        bool Update(News n);
        bool Delete(int id);


    }
}
