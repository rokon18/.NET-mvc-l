using CodeFirst.EF.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace CodeFirst.EF
{
    public class UMSContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}

