using TunaPianoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

public class TunaPianoApiDbContext : DbContext
{

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Song> Songs { get; set; }

    public TunaPianoApiDbContext(DbContextOptions<TunaPianoApiDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist { Id = 1, Name = "M.I.A.", Age = 48, Bio = "Mathangi \"Maya\" Arulpragasam (born 18 July 1975 in Hounslow, London) is an artist, movie graduate and musician. She is the daughter of a Tamil revolutionary. She is best known by her stage name M.I.A. Her music style contains elements of grime, alternative, hip-hop, dance, and electronic music." },
            new Artist { Id = 2, Name = "Cherub", Age = 25, Bio = "Jordan Kelley and Jason Huber met at Nashville's water park Nashville Shores whilst riding boogie boards in the wave pool. Kelley and Huber both attended Middle Tennessee State University and studied music tech. Jordan Kelley is originally from Lincoln Nebraska." }
        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song { Id = 1, Title = "Paper Plans", ArtistId = 1, Album = "Kala" },
            new Song { Id = 2, Title = "Bad Girls", ArtistId = 1, Album = "Matangi" },
            new Song { Id = 3, Title = "Doses and Mimosas", ArtistId = 2, Album = "Year of the Caprese", Length = 3.8f},
            new Song { Id = 4, Title = "Who Knows", ArtistId = 2, Album = "DJ BJ's Faves", Length = 4.5f }
        });

        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, Description = "Electro" },
            new Genre { Id = 2, Description = "Indie" },
            new Genre { Id = 3, Description = "Grime" },
            new Genre { Id = 4, Description = "Pop" }
        });


    }
}

