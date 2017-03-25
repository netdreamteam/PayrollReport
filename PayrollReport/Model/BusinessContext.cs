using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BusinessContext : DbContext
    {
        public BusinessContext()
            : base("BusinessConnection")
        {
        }

        public DbSet<Payroll> Payroll { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<PostRank> PostRank { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
