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

                    context.SaveChanges();

                    // Seed data for Students
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
                        },
                        new Student
                        {
                            FirstName = "Charlie",
                            LastName = "Brown",
                            EnrollmentDate = new DateTime(2021, 10, 5),
                        },
                        new Student
                        {
                            FirstName = "David",
                            LastName = "Wilson",
                            EnrollmentDate = new DateTime(2022, 1, 20),
                        },
                        new Student
                        {
                            FirstName = "Ella",
                            LastName = "Davis",
                            EnrollmentDate = new DateTime(2021, 6, 7),
                        }
                    );

                    context.SaveChanges();

                    // Seed data for Departments
                    var computerScienceDepartment = new Department
                    {
                        Name = "Computer Science",
                        Budget = 1000000.00m,
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "John").ID
                    };
                    var mathematicsDepartment = new Department
                    {
                        Name = "Mathematics",
                        Budget = 800000.00m,
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Jane").ID
                    };
                    var physicsDepartment = new Department
                    {
                        Name = "Physics",
                        Budget = 900000.00m,
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Michael").ID
                    };
                    var chemistryDepartment = new Department
                    {
                        Name = "Chemistry",
                        Budget = 750000.00m,
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Emily").ID
                    };
                    var literatureDepartment = new Department
                    {
                        Name = "Literature",
                        Budget = 600000.00m,
                        InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "William").ID
                    };

                    context.Departments.AddRange(
                        computerScienceDepartment,
                        mathematicsDepartment,
                        physicsDepartment,
                        chemistryDepartment,
                        literatureDepartment
                    );

                    context.SaveChanges();

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
                        },
                        new Course
                        {
                            Title = "Physics Basics",
                            Credits = 3,
                            DepartmentID = computerScienceDepartment.DepartmentID
                        },
                        new Course
                        {
                            Title = "Chemistry Fundamentals",
                            Credits = 4,
                            DepartmentID = mathematicsDepartment.DepartmentID
                        },
                        new Course
                        {
                            Title = "Literary Analysis",
                            Credits = 3,
                            DepartmentID = computerScienceDepartment.DepartmentID
                        }
                    );

                    context.SaveChanges();

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
                        },
                        new OfficeAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Michael").ID,
                            Location = "Room 303",
                        },
                        new OfficeAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Emily").ID,
                            Location = "Room 404",
                        },
                        new OfficeAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "William").ID,
                            Location = "Room 505",
                        }
                    );

                    context.SaveChanges();

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
                        },
                        new CourseAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Michael").ID,
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Physics Basics").CourseID
                        },
                        new CourseAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "Emily").ID,
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Chemistry Fundamentals").CourseID
                        },
                        new CourseAssignment
                        {
                            InstructorID = context.Instructors.FirstOrDefault(i => i.FirstName == "William").ID,
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Literary Analysis").CourseID
                        }
                    );

                    context.SaveChanges();

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
                        },
                        new Enrollment
                        {
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Physics Basics").CourseID,
                            StudentID = context.Students.FirstOrDefault(s => s.FirstName == "Charlie").ID,
                            Grade = Grade.C,
                        },
                        new Enrollment
                        {
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Chemistry Fundamentals").CourseID,
                            StudentID = context.Students.FirstOrDefault(s => s.FirstName == "David").ID,
                            Grade = Grade.D,
                        },
                        new Enrollment
                        {
                            CourseID = context.Courses.FirstOrDefault(c => c.Title == "Literary Analysis").CourseID,
                            StudentID = context.Students.FirstOrDefault(s => s.FirstName == "Ella").ID,
                            Grade = Grade.F,
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
