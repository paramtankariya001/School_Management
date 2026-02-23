using Project.Data;
using Project.Models;

namespace Project.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { 
                    Name = "Sample Student", 
                    Class = "10th A", 
                    RollNo = "STD001", 
                    Username = "student", 
                    Password = "password123", 
                    Email = "student@example.com", 
                    Phone = "1234567890", 
                    DateOfBirth = new DateTime(2008, 1, 1), 
                    Gender = "Male", 
                    Address = "123 Main St" 
                }
            };
            context.Students.AddRange(students);

            var teachers = new Teacher[]
            {
                new Teacher { 
                    Name = "Sample Teacher", 
                    Subject = "Mathematics", 
                    Department = "Science", 
                    Username = "teacher", 
                    Password = "password123", 
                    Email = "teacher@example.com", 
                    Phone = "9876543210", 
                    Qualification = "M.Sc Mathematics", 
                    JoiningDate = new DateTime(2020, 8, 15), 
                    Address = "Faculty Housing A1" 
                }
            };
            context.Teachers.AddRange(teachers);

            var admins = new Admin[]
            {
                new Admin { 
                    Username = "admin", 
                    Password = "adminpassword", 
                    FullName = "System Administrator" 
                }
            };
            context.Admins.AddRange(admins);

            context.SaveChanges();
        }
    }
}
