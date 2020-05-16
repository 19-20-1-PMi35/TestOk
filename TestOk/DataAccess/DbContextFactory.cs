using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccess.Data.Models;

namespace DataAccess
{
    public class DbContextFactory
    {
        public ApplicationDbContext GetDbContext()
        {
            return new ApplicationDbContext(GetOptions());
        }

        private DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), GetConnectionString()).Options;
        }

        private string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("ConnectionStrings__default") ?? GetConnectionStringFromAppSetting();
        }

        private string GetConnectionStringFromAppSetting()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"), false);

            return configurationBuilder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
    }
}
