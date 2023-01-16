using Library.Data.Configurations;
using Library.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public class DataContext : IdentityDbContext
    {

        public DataContext() 
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        protected override void  OnConfiguring(DbContextOptionsBuilder option)
        {
            base.OnConfiguring(option);
            option.UseSqlServer("Data Source=.;Initial Catalog=LibraryDB;Integrated Security=True;");
        }
        protected override void OnModelCreating (ModelBuilder model) 
        {

            base.OnModelCreating(model);

            // this part to calling the configuration class files 
            new FileContainerTypeConfiguration().Configure(model.Entity<FileContainer>());
        }

        public DbSet<FileContainer> FileContainers { get; set; }

    }
}
