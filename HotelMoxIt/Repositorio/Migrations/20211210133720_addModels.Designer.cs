﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio.Models;

namespace Repositorio.Migrations
{
    [DbContext(typeof(HotelDBContext))]
    [Migration("20211210133720_addModels")]
    partial class addModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositorio.Models.Habitacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Capacidad")
                        .HasColumnType("tinyint");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("NroHabitacion")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("Repositorio.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HabitacionId")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("Repositorio.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("HabitacionId")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TipoUsuario")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HabitacionId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Repositorio.Models.Reserva", b =>
                {
                    b.HasOne("Repositorio.Models.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("HabitacionId");

                    b.HasOne("Repositorio.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Habitacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Repositorio.Models.Usuario", b =>
                {
                    b.HasOne("Repositorio.Models.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("HabitacionId");

                    b.Navigation("Habitacion");
                });
#pragma warning restore 612, 618
        }
    }
}
