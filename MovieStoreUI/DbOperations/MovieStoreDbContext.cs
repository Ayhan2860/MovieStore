using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStoreUI.Entities;

namespace MovieStoreUI.DbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerFavoritGenre> CustomerFavoritGenres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>(ConfigureMovieActor);
            modelBuilder.Entity<Movie>(ConfigureDirectorMovie);
            modelBuilder.Entity<CustomerFavoritGenre>(ConfigureFavoritGenre);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureFavoritGenre(EntityTypeBuilder<CustomerFavoritGenre> obj)
        {
           obj.HasKey(c => new {c.GenreId, c.CustomerId});
           obj.HasOne<Customer>(c => c.Customer).WithMany(cf=>cf.CustomerFavoritGenres).HasForeignKey(cid => cid.CustomerId);
           obj.HasOne<Genre>(g => g.Genre).WithMany(fg => fg.CustomerFavoritGenres).HasForeignKey(cid => cid.GenreId);
        }

        private void ConfigureDirectorMovie(EntityTypeBuilder<Movie> obj)
        {
             //obj.HasKey(md => new {md.DirectorId});
             obj.HasOne(md => md.Director).WithMany(md=>md.Movies).HasForeignKey(md => md.DirectorId);
        }

        private void ConfigureMovieActor(EntityTypeBuilder<MovieActor> obj)
        {
            obj.HasKey(mc => new {mc.MovieId, mc.ActorId});
            obj.HasOne(mc=> mc.Movie).WithMany(c => c.MovieActors).HasForeignKey(fg =>fg.MovieId);
            obj.HasOne(mc => mc.Actor).WithMany(m => m.MovieActors).HasForeignKey(fg => fg.ActorId);
        }

        public override int SaveChanges()=> base.SaveChanges();
    }
}