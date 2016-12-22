using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitetativeProject.DataRepository.Models
{
    public class CompetativeDataContext : DbContext
    {

        public CompetativeDataContext()
            : base("CompetativeDataContext")
        {

        }


        public DbSet<City> City { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
