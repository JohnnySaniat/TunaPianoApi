using TunaPianoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7040")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TunaPianoApiDbContext>(builder.Configuration["TunaPianoAPIDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//GENRE



app.MapPost("/genres", (TunaPianoApiDbContext db, int id, string description) =>
{
    var genre = new Genre
    {
        Id = id,
        Description = description
    };

    db.Genres.Add(genre);
    db.SaveChanges();

    return Results.Created($"/genres/{genre.Id}", genre);
});

app.MapDelete("/genres/{genreId}", (TunaPianoApiDbContext db, int genreId) =>
{
    var genre = db.Genres.FirstOrDefault(g => g.Id == genreId);

    if (genre == null)
    {
        return Results.NotFound();
    }

    db.Genres.Remove(genre);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/genres/{genreId}", (TunaPianoApiDbContext db, int genreId) =>
{
    var genre = db.Genres.Include(g => g.Songs).FirstOrDefault(g => g.Id == genreId);

    if (genre == null)
    {
        return Results.NotFound();
    }

    var response = new
    {
        id = genre.Id,
        description = genre.Description,
        songs = genre.Songs.Select(song => new
        {
            id = song.Id,
            title = song.Title,
            artist_id = song.ArtistId,
            album = song.Album,
            length = song.Length
        }).ToList()
    };

    return Results.Ok(response);
});

app.MapGet("/songs/genre/{genreId}", (TunaPianoApiDbContext db, int genreId) =>
{
    
    var songsByGenre = db.Songs
        .Where(s => s.Genres.Any(g => g.Id == genreId))
        .Select(s => new
        {
            id = s.Id,
            title = s.Title,
            artist_id = s.ArtistId,
            album = s.Album,
            length = s.Length
        })
        .ToList();

    if (songsByGenre == null || songsByGenre.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(new { songs = songsByGenre });
});

app.MapGet("/genres", (TunaPianoApiDbContext db) =>
{
    var genres = db.Genres.ToList();

    if (genres == null || genres.Count == 0)
    {
        return Results.NotFound();
    }

    var response = genres.Select(genre => new
    {
        id = genre.Id,
        description = genre.Description
    });

    return Results.Ok(response);
});

app.MapPut("/genres/{genreId}", (TunaPianoApiDbContext db, int genreId, string description) =>
{
    var existingGenre = db.Genres.FirstOrDefault(g => g.Id == genreId);

    if (existingGenre == null)
    {
        return Results.NotFound();
    }

    existingGenre.Description = description;

    db.SaveChanges();

    return Results.Ok(new { id = existingGenre.Id, description = existingGenre.Description });
});

app.MapGet("/genres/popular", (TunaPianoApiDbContext db) =>
{
    var popularGenres = db.Genres
        .Select(genre => new
        {
            id = genre.Id,
            description = genre.Description,
            song_count = genre.Songs.Count()
        })
        .OrderByDescending(genre => genre.song_count)
        .ToList();

    if (popularGenres == null || popularGenres.Count == 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(new { genres = popularGenres });
});



//SONG



app.MapPost("/songs", (TunaPianoApiDbContext db, int id, string title, int artistId, string album, float length) =>
{
    var song = new Song
    {
        Id = id,
        Title = title,
        ArtistId = artistId,
        Album = album,
        Length = length
    };

    db.Songs.Add(song);
    db.SaveChanges();

    return Results.Created($"/songs/{song.Id}", song);
});

app.MapDelete("/songs/{songId}", (TunaPianoApiDbContext db, int songId) =>
{
    var song = db.Songs.FirstOrDefault(s => s.Id == songId);

    if (song == null)
    {
        return Results.NotFound();
    }

    db.Songs.Remove(song);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/songs/{songId}", (TunaPianoApiDbContext db, int songId) =>
{
    var song = db.Songs
        .Include(s => s.Artist)
        .Include(s => s.Genres)
        .FirstOrDefault(s => s.Id == songId);

    if (song == null)
    {
        return Results.NotFound();
    }

    var response = new
    {
        id = song.Id,
        title = song.Title,
        artist = new
        {
            id = song.Artist.Id,
            name = song.Artist.Name,
            age = song.Artist.Age,
            bio = song.Artist.Bio
        },
        album = song.Album,
        length = song.Length,
        genres = song.Genres.Select(genre => new
        {
            id = genre.Id,
            description = genre.Description
        }).ToList()
    };

    return Results.Ok(response);
});

app.MapPut("/songs/{songId}", (TunaPianoApiDbContext db, int songId, string title, int artistId, string album, float length) =>
{
    var existingSong = db.Songs.FirstOrDefault(s => s.Id == songId);

    if (existingSong == null)
    {
        return Results.NotFound();
    }

    existingSong.Title = title;
    existingSong.ArtistId = artistId;
    existingSong.Album = album;
    existingSong.Length = length;

    db.SaveChanges();

    return Results.Ok();
});

app.MapGet("/songs", (TunaPianoApiDbContext db) =>
{
    var songsWithGenres = db.Songs
        .Include(song => song.Genres)
        .ToList();

    if (songsWithGenres == null || songsWithGenres.Count == 0)
    {
        return Results.NotFound();
    }

    var response = songsWithGenres.Select(song => new
    {
        id = song.Id,
        title = song.Title,
        artist_id = song.ArtistId,
        album = song.Album,
        length = song.Length,
        genres = song.Genres.Select(genre => new
        {
            id = genre.Id,
            description = genre.Description
        }).ToList()
    });

    return Results.Ok(response);
});

app.MapPut("/songs/{songId}/genres/{genreId}", (TunaPianoApiDbContext db, int songId, int genreId) =>
{
    var song = db.Songs.Find(songId);
    if (song == null)
    {
        return Results.NotFound();
    }

    var genre = db.Genres.Find(genreId);
    if (genre == null)
    {
        return Results.NotFound();
    }

    if (song.Genres == null)
    {
        song.Genres = new List<Genre>();
    }

    song.Genres.Add(genre);

    db.SaveChanges();

    return Results.Ok();
});



//ARTIST



app.MapPost("/artists", (TunaPianoApiDbContext db, int id, string name, int age, string bio) =>
{
    var artist = new Artist
    {
        Id = id,
        Name = name,
        Age = age,
        Bio = bio
    };

    db.Artists.Add(artist);
    db.SaveChanges();

    return Results.Created($"/artists/{artist.Id}", artist);
});

app.MapDelete("/artists/{artistId}", (TunaPianoApiDbContext db, int artistId) =>
{
    var artist = db.Artists.FirstOrDefault(a => a.Id == artistId);

    if (artist == null)
    {
        return Results.NotFound();
    }

    db.Artists.Remove(artist);
    db.SaveChanges();

    return Results.NoContent();
});

app.MapGet("/artists/{artistId}", (TunaPianoApiDbContext db, int artistId) =>
{
    var artist = db.Artists
                   .Include(a => a.Songs)
                   .FirstOrDefault(a => a.Id == artistId);

    if (artist == null)
    {
        return Results.NotFound();
    }

    var response = new
    {
        id = artist.Id,
        name = artist.Name,
        age = artist.Age,
        bio = artist.Bio,
        song_count = artist.Songs?.Count ?? 0,
        songs = artist.Songs?
                     .Select(song => new
                     {
                         id = song.Id,
                         title = song.Title,
                         album = song.Album,
                         length = song.Length
                     })
                     .ToList()
    };

    return Results.Ok(response);
});

app.MapGet("/artists", (TunaPianoApiDbContext db) =>
{
    var artists = db.Artists.ToList();

    if (artists == null || artists.Count == 0)
    {
        return Results.NotFound();
    }

    var response = artists.Select(artist => new
    {
        id = artist.Id,
        name = artist.Name,
        age = artist.Age,
        bio = artist.Bio
    });

    return Results.Ok(response);
});

app.MapGet("/artists/{artistId}/related", (TunaPianoApiDbContext db, int artistId) =>
{
    var artist = db.Artists.Include(a => a.Songs).ThenInclude(s => s.Genres).FirstOrDefault(a => a.Id == artistId);

    if (artist == null)
    {
        return Results.NotFound();
    }

    var artistSongs = artist.Songs;

    var artistGenres = artistSongs.SelectMany(s => s.Genres).ToList();

    var relatedArtists = db.Artists
                            .Include(a => a.Songs)
                            .ThenInclude(s => s.Genres)
                            .Where(a => a.Id != artistId && a.Songs.Any(s => s.Genres.Any(g => artistGenres.Contains(g))))
                            .Select(a => new
                            {
                                id = a.Id,
                                name = a.Name
                            })
                            .ToList();

    return Results.Ok(new { artists = relatedArtists });
});

app.MapPut("/artists/{artistId}", (TunaPianoApiDbContext db, int artistId, string name, int age, string bio) =>
{
    var existingArtist = db.Artists.FirstOrDefault(a => a.Id == artistId);

    if (existingArtist == null)
    {
        return Results.NotFound();
    }

    existingArtist.Name = name;
    existingArtist.Age = age;
    existingArtist.Bio = bio;

    db.SaveChanges();

    return Results.Ok(new
    {
        id = existingArtist.Id,
        name = existingArtist.Name,
        age = existingArtist.Age,
        bio = existingArtist.Bio
    });
});

app.Run();