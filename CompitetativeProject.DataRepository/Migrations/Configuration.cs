using CompitetativeProject.DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitetativeProject.DataRepository.Migrations
{
    public class Configuration : DbMigrationsConfiguration<CompitetativeProject.DataRepository.Models.CompetativeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }
        protected override void Seed(CompitetativeProject.DataRepository.Models.CompetativeDataContext context)
        {
            context.City.AddOrUpdate(
                 c => c.Name,
                 new City { Id = 1, Name = "Vadodara" },
                 new City { Id = 2, Name = "Rajkot" },
                 new City { Id = 3, Name = "Ahemdabad" },
                 new City { Id = 4, Name = "Surat" }
                       );


            context.Area.AddOrUpdate(
                             c => c.Name,
                             new Area { Id = 1, Name = "1",CityId=1 },
                             new Area { Id = 2, Name = "2", CityId = 1 },
                             new Area { Id = 3, Name = "3", CityId = 1 },
                             new Area { Id = 4, Name = "4", CityId = 1 }
                                   );
            

            context.SaveChanges();
        }
    }
}
