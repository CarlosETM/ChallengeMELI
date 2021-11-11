using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quasar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quasar.Domain.Model
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IANS0V88\SQLEXPRESS; Initial Catalog=ChallengeMELISatellites ;Integrated Security=True",
                b => b.MigrationsAssembly("TopSecret.API"))
                .EnableSensitiveDataLogging(true).UseLoggerFactory(MyLoggerFactory);




            //  optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-IANS0V88\SQLEXPRESS; Initial Catalog=ChallengeMELISatellites ;Integrated Security=True")
            // .EnableSensitiveDataLogging(true)
            //.UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });

        public virtual DbSet<Satellite> Satellite { get; set; }
    }
}
