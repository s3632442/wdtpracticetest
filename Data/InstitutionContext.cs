using Microsoft.EntityFrameworkCore;

namespace EdInstitution.Data
{
    public class InstitutionContext : DbContext
    {
        public InstitutionContext(DbContextOptions<InstitutionContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the composite key for the CourseAssignment entity
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(ca => new { ca.InstructorID, ca.CourseID });

            // Configure the relationship between Instructor and CourseAssignment
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.CourseAssignments)
                .WithOne(ca => ca.Instructor)
                .HasForeignKey(ca => ca.InstructorID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship between Course and CourseAssignment
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseAssignments)
                .WithOne(ca => ca.Course)
                .HasForeignKey(ca => ca.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Define a unique constraint for Department and Instructor
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Instructor)
                .WithOne(i => i.Department)
                .HasForeignKey<Department>(d => d.InstructorID)
                .OnDelete(DeleteBehavior.Restrict);


            // Optionally, you can configure other entity properties and constraints.
            modelBuilder.Entity<Department>()
                .Property(d => d.Budget)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
