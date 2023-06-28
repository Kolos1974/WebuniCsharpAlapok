using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DB;

public partial class FinalExamDataDB : DbContext
{
    public FinalExamDataDB()
    {
    }

    public FinalExamDataDB(DbContextOptions<FinalExamDataDB> options)
        : base(options)
    {
    }

    public virtual DbSet<RepairType> RepairTypes { get; set; }

    public virtual DbSet<Trouble> Troubles { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HP\\Documents\\Webuni\\WebuniCsharpAlapok\\FinalExam\\FinalExamData.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RepairType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RepairTy__3214EC0760B9C255");

            entity.ToTable("RepairType");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trouble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trouble__3214EC07B4700397");

            entity.ToTable("Trouble");

            entity.Property(e => e.Number).HasMaxLength(10);
            entity.Property(e => e.RepairDate).HasColumnType("datetime");
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.TroubleDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Worker__3214EC078F9B3E80");

            entity.ToTable("Worker");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
