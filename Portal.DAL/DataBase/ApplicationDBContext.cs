using Microsoft.EntityFrameworkCore;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.DataBase
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Portal;Integrated Security=True");
        }
        public DbSet<Department> Department { get; set; }

    }
}
