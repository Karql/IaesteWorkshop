using IaesteWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IaesteWorkshop.DB
{
    //migrations  Enable-Migrations -ContextTypeName IaesteWorkshop.DB.DBContext
    //            Add-Migration 'CreateMovies'
    //            Update-Database
    public class DBContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieFile> MovieFiles { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }

        public DBContext()
            : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasOptional(s => s.CoverImage)
                        .WithRequired(ad => ad.Movie);


            base.OnModelCreating(modelBuilder);
        }

    }
}