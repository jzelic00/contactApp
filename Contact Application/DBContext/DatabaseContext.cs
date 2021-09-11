using Contact_Application.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
           
        }     
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Number> Number { get; set; }
        public DbSet<Mail> Mail { get; set; }
           
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Seed();
           base.OnModelCreating(modelBuilder);
        }
    }
}
