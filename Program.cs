using university_System.Models;
using university_System.Repositories;

namespace university_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var DBContext = new ApplicationDbContext();

            var studentRepository = new StudentRepository(DBContext);
            var hostelRepository = new HostelRepository(DBContext);
            var facultyRepository = new FacultyRepository(DBContext);
            var subjectRepository = new SubjectRepository(DBContext);
            var courseRepository = new CourseRepository(DBContext);
            var departmentRepository = new DepartmentRepository(DBContext);
            var examRepository = new ExamRepository(DBContext);
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add new Student ");
                Console.WriteLine("2. Display all Students");
                Console.WriteLine("3. Add new Course");
                Console.WriteLine("4. Display all Courses");
                Console.WriteLine("5. Add new drpartment ");
                Console.WriteLine("6. Display all Drpartment");
                Console.WriteLine("7. Add new Faculty ");
                Console.WriteLine("8. Display all Faculties");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewStudent(studentRepository);
                        break;
                    case "2":
                        DisplayAllStudents(studentRepository);
                        break;
                    case "3":
                        AddNewCourse(courseRepository);
                        break;
                    case "4":
                        DisplayAllCourses(courseRepository);
                        break;
                    case "5":
                        AddNewDepartments(departmentRepository);
                        break;
                    case "6":
                        DisplayAllDepartments(departmentRepository);
                        break;
                    case "7":
                        AddNewFaculty(facultyRepository);
                        break;
                    case "8":
                        DisplayAllFaculty(facultyRepository);
                        break;
                    case "9":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            
            
        }

        static void DisplayAllStudents(StudentRepository repository)
        {
            var students = repository.GetAllStudents();
            Console.WriteLine("\nStudents:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.SID}: {student.FName} {student.lName} - Address: {student.Address}" +
                    $" - PhoneNum: {student.PhoneNum} - Age: {student.Age} ");
            }
        }

        static void AddNewStudent(StudentRepository repository)
        {
            Console.Write("\nEnter Student first name: ");
            var fname = Console.ReadLine();
            Console.Write("Enter Student last name: ");
            var lname = Console.ReadLine();
            Console.Write("Enter Date Of Birth ('yyyy-mm-dd'): ");
            var DOB = DateTime.Parse( Console.ReadLine());
            Console.Write("\nEnter Student Address: ");
            var Address = Console.ReadLine();
            Console.Write("Enter Student Phone Number: ");
            var Phone = Console.ReadLine();
            var age = DateTime.Now.Year - DOB.Year ;
            try
            {
                var student = new Student { FName = fname, lName = lname, DOB = DOB, Address = Address, PhoneNum = Phone , Age = age };
                repository.AddStudent(student);
                Console.WriteLine("Student added successfully!");
            }
            catch (Exception ex) { Console.WriteLine("Faild to Add Student!"); }

        }

        static void DisplayAllCourses(CourseRepository repository)
        {
            var courses = repository.GetAllCourses();
            Console.WriteLine("\nCourses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.CID}: Course Name: {course.CName} ");
            }
        }

        static void AddNewCourse(CourseRepository repository)
        {
            Console.Write("\nEnter Course name: ");
            var Cname = Console.ReadLine();
            Console.Write("Enter Course Duration: ");
            var duration = int.Parse(Console.ReadLine());
          
            try
            {
                var course = new Course { CName = Cname, Duration = duration };
                repository.AddCourse(course);
                Console.WriteLine("course added successfully!");
            }
            catch (Exception ex) { Console.WriteLine("Faild to Add course!"); }

        }

        static void DisplayAllDepartments(DepartmentRepository repository)
        {
            var departments = repository.GetAllDepartments();
            Console.WriteLine("\nDepartments:");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentId}:  - Department Name: {department.DepartmentName} ");
            }
        }
        static void AddNewDepartments(DepartmentRepository repository)
        {
            Console.Write("\nEnter Department name: ");
            var Dname = Console.ReadLine();
            try
            {
                var drpartment = new Department { DepartmentName = Dname};
                repository.AddDepartment(drpartment);
                Console.WriteLine("drpartment added successfully!");
            }
            catch (Exception ex) { Console.WriteLine("Faild to Add drpartment!"); }

        }

        static void AddNewFaculty(FacultyRepository repository)
        {
            Console.Write("\nEnter Faculty name: ");
            var fname = Console.ReadLine();
            Console.Write("Enter salary: ");
            var salary = double.Parse(Console.ReadLine());
            
            Console.Write("Enter Faculty Phone Number: ");
            var Phone = Console.ReadLine();
            Console.Write("Enter Department ID: ");
            var DID = int.Parse(Console.ReadLine());
      
            try
            {
                var faculty = new Faculty {Faculty_Name = fname , Salary = salary, Mobile_No = Phone , DepartmentId = DID};
                repository.AddFaculty(faculty);
                Console.WriteLine("faculty added successfully!");
            }
            catch (Exception ex) { Console.WriteLine("Faild to Add faculty!"); }

        }

        static void DisplayAllFaculty(FacultyRepository repository)
        {
            var faculties = repository.GetAllFaculties();
            Console.WriteLine("\nFaculties:");
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"{faculty.FId}: {faculty.Faculty_Name} - Salary: {faculty.Salary}" +
                    $" - PhoneNum: {faculty.Mobile_No} - DepartmentId: {faculty.DepartmentId} ");
            }
        }
    }


}
