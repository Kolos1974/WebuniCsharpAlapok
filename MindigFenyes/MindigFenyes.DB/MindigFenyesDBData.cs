using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MindigFenyes.DB;

public partial class MindigFenyesDBData : DbContext
{
    public MindigFenyesDBData()
    {
    }

    public MindigFenyesDBData(DbContextOptions<MindigFenyesDBData> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Trouble> Troubles { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kolos\\Documents\\Webuni\\WebuniCsharpAlapok\\MindigFenyes\\MindigFenyesDB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07EDB05691");

            entity.ToTable("Address");

            entity.Property(e => e.Number).HasMaxLength(20);
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<Trouble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0756E9F596");

            entity.ToTable("Trouble");

            entity.Property(e => e.RepairDate).HasColumnType("datetime");
            entity.Property(e => e.RepairType).HasColumnName("RepairType ");
            entity.Property(e => e.TroubleDate)
                .HasColumnType("datetime")
                .HasColumnName("TroubleDate ");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Worker__3214EC0778AB5E5E");

            entity.ToTable("Worker");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
