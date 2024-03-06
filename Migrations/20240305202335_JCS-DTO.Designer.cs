﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TunaPianoApi.Migrations
{
    [DbContext(typeof(TunaPianoApiDbContext))]
    [Migration("20240305202335_JCS-DTO")]
    partial class JCSDTO
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("TunaPianoApi.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 48,
                            Bio = "Mathangi \"Maya\" Arulpragasam (born 18 July 1975 in Hounslow, London) is an artist, movie graduate and musician. She is the daughter of a Tamil revolutionary. She is best known by her stage name M.I.A. Her music style contains elements of grime, alternative, hip-hop, dance, and electronic music.",
                            Name = "M.I.A."
                        },
                        new
                        {
                            Id = 2,
                            Age = 25,
                            Bio = "Jordan Kelley and Jason Huber met at Nashville's water park Nashville Shores whilst riding boogie boards in the wave pool. Kelley and Huber both attended Middle Tennessee State University and studied music tech. Jordan Kelley is originally from Lincoln Nebraska.",
                            Name = "Cherub"
                        });
                });

            modelBuilder.Entity("TunaPianoApi.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Electro"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Indie"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Grime"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pop"
                        });
                });

            modelBuilder.Entity("TunaPianoApi.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Kala",
                            ArtistId = 1,
                            Length = 0f,
                            Title = "Paper Plans"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Matangi",
                            ArtistId = 1,
                            Length = 0f,
                            Title = "Bad Girls"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Year of the Caprese",
                            ArtistId = 2,
                            Length = 3.8f,
                            Title = "Doses and Mimosas"
                        },
                        new
                        {
                            Id = 4,
                            Album = "DJ BJ's Faves",
                            ArtistId = 2,
                            Length = 4.5f,
                            Title = "Who Knows"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPianoApi.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPianoApi.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPianoApi.Models.Song", b =>
                {
                    b.HasOne("TunaPianoApi.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPianoApi.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
