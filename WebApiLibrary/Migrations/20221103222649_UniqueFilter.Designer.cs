﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiLibrary;

#nullable disable

namespace WebApiLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221103222649_UniqueFilter")]
    partial class UniqueFilter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AutorUsuario", b =>
                {
                    b.Property<int>("SuscripcionesId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosSuscritosId")
                        .HasColumnType("int");

                    b.HasKey("SuscripcionesId", "UsuariosSuscritosId");

                    b.HasIndex("UsuariosSuscritosId");

                    b.ToTable("AutorUsuario");
                });

            modelBuilder.Entity("WebApiLibrary.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("WebApiLibrary.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadDePaginas")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDePublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreEditorial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("URLDescarga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("ISBN")
                        .IsUnique();

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("WebApiLibrary.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AutorUsuario", b =>
                {
                    b.HasOne("WebApiLibrary.Models.Autor", null)
                        .WithMany()
                        .HasForeignKey("SuscripcionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiLibrary.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosSuscritosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiLibrary.Models.Libro", b =>
                {
                    b.HasOne("WebApiLibrary.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("WebApiLibrary.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}
