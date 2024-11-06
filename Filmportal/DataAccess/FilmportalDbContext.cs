using DataAccess.Enities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class FilmportalDbContext : DbContext
{
    public DbSet<AgeLimit> AgeLimits { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<ResourceToView> Resources { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public FilmportalDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeLimit>().HasKey(x => x.Id);
        modelBuilder.Entity<Country>().HasKey(x => x.Id);
        modelBuilder.Entity<Genre>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<ResourceToView>().HasKey(x => x.Id);
        
        modelBuilder.Entity<Person>().HasKey(x => x.Id);
        modelBuilder.Entity<Person>()
            .HasOne(x => x.Country)
            .WithMany(x => x.Persons)
            .HasForeignKey(x => x.CountryId);
        
        modelBuilder.Entity<Film>().HasKey(x => x.Id);
        modelBuilder.Entity<Film>()
            .HasOne(x => x.AgeLimit)
            .WithMany(x => x.Films)
            .HasForeignKey(x => x.AgeLimitId);
        modelBuilder.Entity<Film>()
            .HasOne(x => x.Creator)
            .WithMany(x => x.Films)
            .HasForeignKey(x => x.CreatorId);
        modelBuilder.Entity<Film>()
            .HasMany(x => x.Countries)
            .WithMany(x => x.Films)
            .UsingEntity(t => t.ToTable("films_countries"));
        modelBuilder.Entity<Film>()
            .HasMany(x => x.Genres)
            .WithMany(x => x.Films)
            .UsingEntity(t => t.ToTable("films_genres"));
        modelBuilder.Entity<Film>()
            .HasMany(x => x.Actors)
            .WithMany(x => x.FilmsOfActor)
            .UsingEntity(t => t.ToTable("films_actors"));
        modelBuilder.Entity<Film>()
            .HasMany(x => x.Directors)
            .WithMany(x => x.FilmsOfDirector)
            .UsingEntity("films_directors");

        modelBuilder.Entity<FilmResource>().HasKey(x => x.Id);
        modelBuilder.Entity<FilmResource>()
            .HasOne(x => x.Film)
            .WithMany()
            .HasForeignKey(x => x.FilmId);
        modelBuilder.Entity<FilmResource>()
            .HasOne(x => x.Resource)
            .WithMany()
            .HasForeignKey(x => x.ResourceId);
    }
}