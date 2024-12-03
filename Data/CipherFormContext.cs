using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task1.Models;

public partial class CipherFormContext : DbContext
{
    

    public CipherFormContext(DbContextOptions<CipherFormContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=SONIYA\\SQLEXPRESS;Database=CipherForm;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9931324679");

            entity.HasIndex(e => e.RollNumber, "UQ__Students__E9F06F16454D6862").IsUnique();

            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A8FF7AAC72");

            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.Language).HasMaxLength(50);
            entity.Property(e => e.SubjectName).HasMaxLength(100);
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubjectT__3214EC076A06741F");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectTe__Subje__59FA5E80");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectTe__Teach__59063A47");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF25964D83F9684");

            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.TeacherName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
