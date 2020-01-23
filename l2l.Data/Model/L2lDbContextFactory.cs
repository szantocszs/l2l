using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace l2l.Data.Model
{
    public class L2lDbContextFactory : IDesignTimeDbContextFactory<L2lDbContext>
    {
        public L2lDbContext CreateDbContext(string[] args)
        {
            var obuilder = new DbContextOptionsBuilder<L2lDbContext>();   
            

            // állományok melyik könyvtrában vannak. SetBasePath
            // Éppen futó alkalmazás könyvátra lesz.

            string basePath = Directory.GetCurrentDirectory();
            string environment = Environment.GetEnvironmentVariable(GlobalStrings.AspnetCoreEnvironment);

            var cbuilder = new ConfigurationBuilder()
                            .SetBasePath(basePath)
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{environment}.json", true)
                            .AddEnvironmentVariables();

            var config = cbuilder.Build();
            var connectionString = config.GetConnectionString(GlobalStrings.ConnectionName);

            obuilder.UseSqlite(connectionString);



            var options = obuilder.Options;            
            return new L2lDbContext(options);
        }
    }
}