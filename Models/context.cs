using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class context : DbContext
    {
        private static context _context;
        public context() : base("sql1") { }
        public static context AgetDB()
        {
            if (_context == null)
                _context = new context();
            return _context;
        }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<EnergyEfficiency> EnergyEfficiencies { get; set; }
        public DbSet<Qestion> Qestions { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}
