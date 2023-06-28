using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WinFormsApp1
{
    public partial class EmberAdatok : DbContext
    {
        public EmberAdatok()
        {
        }

        public EmberAdatok(DbContextOptions<EmberAdatok> options)
            : base(options)
        {
        }

        public virtual DbSet<Emberek> Embereks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kolos\\Documents\\Webuni\\WebuniCsharpAlapok\\Live20230523_WinFormsApp1\\adatok.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emberek>(entity =>
            {
                entity.ToTable("Emberek");

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
