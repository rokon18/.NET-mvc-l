namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.NEWSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.NEWSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.\
    //        var categories = new List<Category>
    //{
    //    new Category { Id = 1, Name = "Technology" },
    //    new Category { Id = 2, Name = "Health" },
    //    new Category { Id = 3, Name = "Education" }
    //};

    //        categories.ForEach(c => context.Categories.AddOrUpdate(cat => cat.Id, c));

    //        // Seed Items
    //        var news
    //            = new List<News>
    //{
    //    new News { Id = 1, Title = "AI Revolution", Date = DateTime.Now, cId = 1 },
    //    new News { Id = 2, Title = "Mental Wellness", Date = DateTime.Now, cId = 2 },
    //    new News { Id = 3, Title = "Online Learning", Date = DateTime.Now, cId = 3 }
    //};

    //        news.ForEach(i => context.Newses.AddOrUpdate(it => it.Id, i));

    //        context.SaveChanges();
        }
    }
}
