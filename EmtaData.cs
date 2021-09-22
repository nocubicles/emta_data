using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace estonian_companies
{

    public class CustomerDataContext : DbContext
    {
        public DbSet<EmtaData> customerData {get;set;}

        public string DbPath { get; private set; }

        public CustomerDataContext()
        {
            var folder = Environment.SpecialFolder.Personal;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Data{System.IO.Path.DirectorySeparatorChar}emta_data.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmtaData>().HasKey(u => new {
                u.RegistryCode,
                u.Year,
                u.Quarter
            });
        }
    }
    public class EmtaData
    {
        [Key]
        [Column(Order = 1)]
        public string RegistryCode { get; set; }
        public string Name { get; set; }
        public bool RegisteredVAT { get; set; }
        public decimal StateTax { get; set; }
        public decimal WorkforceTax { get; set; }
        public decimal Revenue { get; set; }
        public decimal EmployeeCount { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Year { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Quarter { get; set; }
        public string YearQuarter { get; set; }
    }
}
