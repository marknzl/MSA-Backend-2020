using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentSIMS.Models;
using System;
using System.Collections.Specialized;

namespace StudentSIMS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext()
        {

        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public static NameValueCollection AppSettings { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("schoolSIMSConnection"));
        }
    }
}
