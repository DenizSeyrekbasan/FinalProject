using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tablolari ile proje classslarini baglamak, hangi veritabanina baglanacagini buldu
    //
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //projenin hangi veritabani ile iliskili oldugunu belirttigimiz 
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=master;Trusted_Connection=True;"); 
        }

        //hangi classimiz hangi tabloya karsilik geliyor
        public DbSet<Product>Products { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee>Employees { get; set; }

    }
}
