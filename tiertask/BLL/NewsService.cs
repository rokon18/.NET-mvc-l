using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<News, NewsCatDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryNewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<NewsDTO> Get()
        {
            var data = DataAccessFactory.NewsData().Get();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public NewsDTO Get(int id)
        {
            var data = DataAccessFactory.NewsData().Get(id);
            return GetMapper().Map<NewsDTO>(data);
        }
        public NewsDTO Get(DateTime date)
        {
            var data = DataAccessFactory.NewsData().Get(date);
            return GetMapper().Map<NewsDTO>(data);
        }
        public NewsDTO Get(DateTime date, CategoryDTO cname)
        {
            var data = DataAccessFactory.NewsData().Get(date, GetMapper().Map<Category>(cname));
            return GetMapper().Map<NewsDTO>(data);
        }
        public NewsDTO Get(CategoryDTO cname)
        {
            var data = DataAccessFactory.NewsData().Get(GetMapper().Map<Category>(cname));
            return GetMapper().Map<NewsDTO>(data);
        }

        public bool Update(NewsDTO n)
        {
            var data = GetMapper().Map<News>(n);
            return DataAccessFactory.NewsData().Update(data);
        }
        public bool Delete(int id)
        {
            return DataAccessFactory.NewsData().Delete(id);
        }



    }
}
