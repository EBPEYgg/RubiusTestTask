﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RubiusTestTask.DataAccess.Data;

#nullable disable

namespace RubiusTestTask.DataAccess.Migrations
{
    [DbContext(typeof(MusicDbContext))]
    partial class MusicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.AlbumEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("MusicianEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("MusicianId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MusicianEntityId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.MusicianEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CareerStartYear")
                        .HasColumnType("integer");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.TrackEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AlbumEntityId")
                        .HasColumnType("bigint");

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<string>("Duration")
                        .HasColumnType("text");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsListened")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AlbumEntityId");

                    b.ToTable("Tracks", t =>
                        {
                            t.HasCheckConstraint("CK_Track_Rating", "\"Rating\" IN (-1, 0, 1)");
                        });
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.AlbumEntity", b =>
                {
                    b.HasOne("RubiusTestTask.DataAccess.Entities.MusicianEntity", null)
                        .WithMany("Albums")
                        .HasForeignKey("MusicianEntityId");
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.TrackEntity", b =>
                {
                    b.HasOne("RubiusTestTask.DataAccess.Entities.AlbumEntity", null)
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumEntityId");
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.AlbumEntity", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("RubiusTestTask.DataAccess.Entities.MusicianEntity", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
