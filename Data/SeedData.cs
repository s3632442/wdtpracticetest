namespace EdInstitution.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<InstitutionContext>();

            if (context.Courses.Any())

                // Seed data for Courses
                context.Courses.AddRange(
                    new Course
                    {
                        CourseID = 1,
                        Title = "Introduction to Programming",
                        Credits = 3,
                        DepartmentID = 1
                    },
                    new Course
                    {
                        CourseID = 2,
                        Title = "Database Management",
                        Credits = 4,
                        DepartmentID = 2
                    }
                );

            // Seed data for Instructors
            context.Instructors.AddRange(
                new Instructor
                {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    HireDate = new DateTime(2020, 1, 15)
                },
                new Instructor
                {
                    ID = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    HireDate = new DateTime(2018, 5, 10)
                }
            );

            // Seed data for CourseAssignments
            context.CourseAssignments.AddRange(
                new CourseAssignment
                {
                    InstructorID = 1,
                    CourseID = 1
                },
                new CourseAssignment
                {
                    InstructorID = 2,
                    CourseID = 2
                }
            );

            // Seed data for Departments
            context.Departments.AddRange(
                new Department
                {
                    DepartmentID = 1,
                    Name = "Computer Science",
                    Budget = 1000000.00m,
                },
                new Department
                {
                    DepartmentID = 2,
                    Name = "Mathematics",
                    Budget = 800000.00m,
                }
            );

            // Seed data for Enrollments
            context.Enrollments.AddRange(
                new Enrollment
                {
                    EnrollmentID = 1,
                    CourseID = 1,
                    StudentID = 1,
                    Grade = Grade.A,
                },
                new Enrollment
                {
                    EnrollmentID = 2,
                    CourseID = 2,
                    StudentID = 2,
                    Grade = Grade.B,
                }
            );

            // Seed data for OfficeAssignments
            context.OfficeAssignments.AddRange(
                new OfficeAssignment
                {
                    InstructorID = 1,
                    Location = "Room 101",
                },
                new OfficeAssignment
                {
                    InstructorID = 2,
                    Location = "Room 202",
                }
            );

            // Seed data for Students
            context.Students.AddRange(
                new Student
                {
                    ID = 1,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    EnrollmentDate = new DateTime(2022, 9, 1),
                },
                new Student
                {
                    ID = 2,
                    FirstName = "Bob",
                    LastName = "Smith",
                    EnrollmentDate = new DateTime(2022, 8, 15),
                }
            );

        }
    }
}
