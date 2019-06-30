﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Videotheque.DataAccess;

namespace Videotheque.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    [Migration("20190630105801_ami")]
    partial class ami
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Videotheque.Model.Ami", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Nom");

                    b.Property<string>("Prenom");

                    b.HasKey("Id");

                    b.ToTable("Amis");
                });

            modelBuilder.Entity("Videotheque.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Videotheque.Model.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age_Minimum");

                    b.Property<bool>("AudioDescription");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("Date_Creation");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Langue_Media");

                    b.Property<int>("Langue_VO");

                    b.Property<int>("Note");

                    b.Property<int>("Sous_Titre");

                    b.Property<int>("Statut");

                    b.Property<bool>("Support_Mumerique");

                    b.Property<bool>("Support_Physique");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Titre");

                    b.HasKey("Id");

                    b.ToTable("Medias");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");
                });

            modelBuilder.Entity("Videotheque.Model.Media_Genre", b =>
                {
                    b.Property<int>("Id_Media");

                    b.Property<int>("Id_Genre");

                    b.HasKey("Id_Media", "Id_Genre");

                    b.HasIndex("Id_Genre");

                    b.ToTable("MediasGenres");
                });

            modelBuilder.Entity("Videotheque.Model.Film", b =>
                {
                    b.HasBaseType("Videotheque.Model.Media");

                    b.Property<TimeSpan>("Duree");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("Videotheque.Model.Serie", b =>
                {
                    b.HasBaseType("Videotheque.Model.Media");

                    b.Property<int>("Duree")
                        .HasColumnName("Serie_Duree");

                    b.Property<int>("Nb_Saisons");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("Videotheque.Model.Media_Genre", b =>
                {
                    b.HasOne("Videotheque.Model.Genre", "Genre")
                        .WithMany("Media")
                        .HasForeignKey("Id_Genre")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Model.Media", "Media")
                        .WithMany("Genre")
                        .HasForeignKey("Id_Media")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
