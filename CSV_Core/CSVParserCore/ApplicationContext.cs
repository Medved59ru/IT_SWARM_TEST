using CSVParserCore.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParserCore
{
    public class ApplicationContext:DbContext
    {
        public DbSet<City> Cities => Set<City>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Sex> Sexes => Set<Sex>();
        public DbSet<ListInfo> ListInfos => Set<ListInfo>();
        public DbSet<Contact> Contacts => Set<Contact>();

       
        public ApplicationContext()
        {
            //Database.EnsureDeleted(); //раскомментировать если нужно снести базу
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CSVapp.db");
        }
    }
}
