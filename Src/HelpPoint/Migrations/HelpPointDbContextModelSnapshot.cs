﻿// <auto-generated />
using System;
using HelpPoint.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelpPoint.Migrations
{
    [DbContext(typeof(HelpPointDbContext))]
    partial class HelpPointDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Empleado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid>("UnidadId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UnidadId");

                    b.ToTable("Empleados", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.EstadoSolicitud", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("EstadoSolicitudes", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ParentId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Menus", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.RoleMenu", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("RoleMenus", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.SupportRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<Guid?>("EmpleadoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EstadoId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaResolucion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("TokenVerificacion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("EstadoId");

                    b.ToTable("SupportRequests", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Unidad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Unidades", "Support");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.Notificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ExitoEnvio")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaEnvio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Mensaje")
                        .HasColumnType("text");

                    b.Property<Guid?>("TicketId")
                        .HasColumnType("uuid");

                    b.Property<string>("TipoNotificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("Notificaciones", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Tags", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodigoEstado")
                        .IsRequired()
                        .HasColumnType("character varying(10)");

                    b.Property<Guid>("CreatedByUserId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<int>("EstadoId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrdenEnTablero")
                        .HasColumnType("integer");

                    b.Property<Guid>("PrioridadId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SupportRequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoEstado");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("SupportRequestId");

                    b.ToTable("Tickets", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketAsignacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid");

                    b.Property<int>("TiempoEmpleadoMinutos")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketAsignaciones", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketComentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TicketId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComentarios", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketEstado", b =>
                {
                    b.Property<string>("Codigo")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Codigo");

                    b.ToTable("TicketEstados", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketHistorial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CampoModificado")
                        .HasColumnType("text");

                    b.Property<Guid?>("ChangedByUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("FechaCambio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid");

                    b.Property<string>("ValorAnterior")
                        .HasColumnType("text");

                    b.Property<string>("ValorNuevo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketHistorial", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketPrioridad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("TicketPrioridades", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketTag", b =>
                {
                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("TagId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("TicketId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TicketTags", "Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.RoleClaims", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Users");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01956042-3344-70a8-99d7-7a337595c1ea"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("01956042-3344-7953-b575-59d8f088a283"),
                            Name = "AreaManager",
                            NormalizedName = "AREAMANAGER"
                        },
                        new
                        {
                            Id = new Guid("01956042-3344-7a85-8117-020290a145f9"),
                            Name = "SupportStaff",
                            NormalizedName = "SUPPORTSTAFF"
                        });
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockOutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LockOutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "Users");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.UserRoles", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Users");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Empleado", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Support.Unidad", "Unidad")
                        .WithMany()
                        .HasForeignKey("UnidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Menu", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Support.Menu", "Parent")
                        .WithMany("SubMenus")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.RoleMenu", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Support.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpPoint.Infrastructure.Models.Users.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.SupportRequest", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Support.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HelpPoint.Infrastructure.Models.Support.EstadoSolicitud", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.Notificacion", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpPoint.Infrastructure.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.Ticket", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.TicketEstado", "Estado")
                        .WithMany()
                        .HasForeignKey("CodigoEstado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.TicketPrioridad", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HelpPoint.Infrastructure.Models.Support.SupportRequest", "SupportRequest")
                        .WithMany()
                        .HasForeignKey("SupportRequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Estado");

                    b.Navigation("Prioridad");

                    b.Navigation("SupportRequest");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketAsignacion", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketComentario", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketHistorial", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Ticket.TicketTag", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HelpPoint.Infrastructure.Models.Ticket.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.RoleClaims", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Users.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Users.UserRoles", b =>
                {
                    b.HasOne("HelpPoint.Infrastructure.Models.Users.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HelpPoint.Infrastructure.Models.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HelpPoint.Infrastructure.Models.Support.Menu", b =>
                {
                    b.Navigation("SubMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
