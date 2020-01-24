using App.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace App.data.Db
{
    public class RestaurantContext : DbContext
    {
        private String connectionString { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            connectionString = @"server=delicemachine\mssqlserver01; database = netDb; trusted_connection = true;";
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Restaurant>()
                .HasOne(r => r.adresse)
                .WithOne(a => a.resto)
                .HasForeignKey<Adresse>(r => r.resto_ID);

            builder.Entity<Restaurant>()
                .HasOne(r => r.note)
                .WithOne(a => a.resto)
                .HasForeignKey<Note>(r => r.resto_ID);
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
