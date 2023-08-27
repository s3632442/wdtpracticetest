
namespace EdInstitution.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<InstitutionContext>();

                if (!context.Courses.Any())
                {
                    // Seed data for Instructors
                    context.Instructors.AddRange(
                    new Instructor
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        HireDate = new DateTime(2020, 1, 15)
                    },
                    new Instructor
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        HireDate = new DateTime(2018, 5, 10)
                    },
                    new Instructor
                    {
                        FirstName = "Michael",
                        LastName = "Johnson",
                        HireDate = new DateTime(2019, 8, 20)
                    },
                    new Instructor
                    {
                        FirstName = "Emily",
                        LastName = "Brown",
                        HireDate = new DateTime(2017, 3, 5)
                    },
                    new Instructor
                    {
                        FirstName = "William",
                        LastName = "Anderson",
                        HireDate = new DateTime(2021, 6, 12)
                    }
                    );

                    context.SaveChanges(); // Save instructors before referencing them in other entities

                    context.Students.AddRange(
                           new Student
                           {
                               FirstName = "Alice",
                               LastName = "Johnson",
                               EnrollmentDate = new DateTime(2022, 9, 1),
                           },
                           new Student
                           {
                               FirstName = "Bob",
                               LastName = "Smith",
                               EnrollmentDate = new DateTime(2022, 8, 15),
                           }
                       );
                    context.SaveChanges();

                    // Seed data for Departments
                    var computerScienceDepartment = new Department
                    {
                        Name = "Computer Science",
                        Budget = 1000000.00m,
                        InstructorID = 1 // Set the InstructorID to the appropriate value
                    };
                    var mathematicsDepartment = new Department
                    {
                        Name = "Mathematics",
                        Budget = 800000.00m,
                        InstructorID = 2 // Set the InstructorID to the appropriate value
                    };

                    context.Departments.AddRange(computerScienceDepartment, mathematicsDepartment);
                    context.SaveChanges(); // Save departments before referencing them in other entities

                    // Seed data for Courses
                    context.Courses.AddRange(
                        new Course
                        {
                            Title = "Introduction to Programming",
                            Credits = 3,
                            DepartmentID = computerScienceDepartment.DepartmentID
                        },
                        new Course
                        {
                            Title = "Database Management",
                            Credits = 4,
                            DepartmentID = mathematicsDepartment.DepartmentID
                        }
                    );

                    context.SaveChanges(); // Save courses before referencing them in other entities
                }


                // Seed data for CourseAssignments
                context.CourseAssignments.AddRange(
                    new CourseAssignment
                    {
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "John").ID,
                        CourseID = context.Courses.FirstOrDefault(c => c.Title == "Introduction to Programming").CourseID
                    },
                    new CourseAssignment
                    {
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Jane").ID,
                        CourseID = context.Courses.FirstOrDefault(c => c.Title == "Database Management").CourseID
                    }
                );

                // Seed data for OfficeAssignments
                context.OfficeAssignments.AddRange(
                    new OfficeAssignment
                    {
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "John").ID,
                        Location = "Room 101",
                    },
                    new OfficeAssignment
                    {
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Jane").ID,
                        Location = "Room 202",
                    }
                );

                // Seed data for Enrollments
                context.Enrollments.AddRange(
                    new Enrollment
                    {
                        CourseID = context.Courses.FirstOrDefault(c => c.Title == "Introduction to Programming").CourseID,
                        StudentID = context.Students.FirstOrDefault(s => s.FirstName == "Alice").ID,
                        Grade = Grade.A,
                    },
                    new Enrollment
                    {
                        CourseID = context.Courses.FirstOrDefault(c => c.Title == "Database Management").CourseID,
                        StudentID = context.Students.FirstOrDefault(s => s.FirstName == "Bob").ID,
                        Grade = Grade.B,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
