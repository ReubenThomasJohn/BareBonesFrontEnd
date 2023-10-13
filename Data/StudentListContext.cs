using Models;
using Microsoft.EntityFrameworkCore;

namespace BareBonesFrontEnd.Data;

public class StudentListContext : DbContext
{
    public StudentListContext(DbContextOptions<StudentListContext> options)
        : base(options)
    {

    }

    public DbSet<Student> Students => Set<Student>(); // This creates an empty initial instance.
    public DbSet<State> States => Set<State>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<State>()
        .HasMany(e => e.Students)
        .WithOne(e => e.State)
        .HasForeignKey(e => e.StateId)
        .IsRequired();

        // modelBuilder.Entity<StudentWithStateName>().HasNoKey();

        modelBuilder.Entity<State>().HasData(
        new State
        {
            Id = 1,
            StateName = "Kerala"
        },
        new State
        {
            Id = 2,
            StateName = "Tamil Nadu"
        });

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                Name = "Raj",
                Rank = 1,
                StateId = 1 // Associate this student with State1
            },
            new Student
            {
                Id = 2,
                Name = "Prakash",
                Rank = 2,
                StateId = 2 // Associate this student with State2
            });
    }
}