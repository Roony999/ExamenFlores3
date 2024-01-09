using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenFlores3.Models.Entities;

public partial class FloresContext : DbContext
{
    public FloresContext()
    {
    }

    public FloresContext(DbContextOptions<FloresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Datos> Datos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Datos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("datos")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.NombreFlor).HasMaxLength(45);
            entity.Property(e => e.Origen).HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
