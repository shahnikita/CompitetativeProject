using Autofac;
using CompitetativeProject.DataRepository.Migrations;
using CompitetativeProject.DataRepository.Models;
using CompitetativeProject.Util.GlobalUtils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompitetativeProject.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize(IComponentContext componentContext)
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompetativeDataContext, Configuration>());
                using (var dbContext = componentContext.Resolve<DbContext>())
                {
                   
                    dbContext.Database.Initialize(false);
                    //if (!dbContext.Database.Exists())
                    //{
                    //    dbContext.Database.Initialize(false);

                    //}
                  

                }
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, typeof(DatabaseConfig));
                throw;
            }
        }
    }
}