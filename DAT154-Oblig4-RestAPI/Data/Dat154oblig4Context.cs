using System;
using System.Collections.Generic;
using DAT154_Oblig4_RestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DAT154_Oblig4_RestAPI.Data;

public partial class Dat154oblig4Context : DbContext
{
    public Dat154oblig4Context()
    {
    }

    public Dat154oblig4Context(DbContextOptions<Dat154oblig4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Task_db> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3213E83FBBB57C47");

            entity.ToTable("Reservations", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Reservati__custo__367C1819");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Reservati__room___37703C52");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3213E83F145BC175");

            entity.ToTable("Rooms", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Beds).HasColumnName("beds");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Quality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quality");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("size");
        });

        modelBuilder.Entity<Task_db>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3213E83F566EC8FD");

            entity.ToTable("Tasks", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Room).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Tasks__room_id__3B40CD36");

            entity.HasOne(d => d.Staff).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Tasks__staff_id__3A4CA8FD");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F2DB75062");

            entity.ToTable("Users", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Staff).HasColumnName("staff");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
