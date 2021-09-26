using Microsoft.EntityFrameworkCore;
using SimplePro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePro.EntityFramework
{
   public  class SimpleProDbContext:DbContext
    {
      public   DbSet<User> Users { get; set; }
      public  DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=SimplePro; Trusted_Connection=true;");


            base.OnConfiguring(optionsBuilder);
        }

    }
}
