using Microsoft.EntityFrameworkCore;
using Portal.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Portal;Integrated Security=True");
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }


    }
}
