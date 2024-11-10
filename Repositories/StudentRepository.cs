using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(e => e.Courses)
                .ThenInclude(e => e.Department).ThenInclude(e => e.Exams)
                .Include(e => e.Hostel);
        }

        public Student GetStudentById (int SID)
        {
            return _context.Students.Include(e => e.Courses)
                .ThenInclude(e => e.Department).ThenInclude(e => e.Exams)
                .Include(e => e.Hostel).FirstOrDefault(e => e.SID == SID);

        }

        //AddStudent: Add a new student to the database. 
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        //UpdateStudent: Update existing student information.
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        //DeleteStudent: Remove a student by ID and ensure related data integrity. 
        public void DeleteStudent(int sid)
        {
            var student = GetStudentById(sid);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        //GetStudentsByCourse: Fetch all students enrolled in a specific course. 
        public IEnumerable<Student> GetStudentsByCourse (int courseId)
        {
            return _context.Students.Include(e => e.Courses).Where(e=> e.Courses.Any(e => e.CID == courseId)).ToList();
        }


        //GetStudentsInHostel: List students living in a specified hostel.
        public IEnumerable<Student> GetStudentsInHostel(int HostelID)
        {
            return _context.Students.Include(e => e.Hostel).Where(e=> e.Hostel.HostelID == HostelID).ToList();
         }

        //SearchStudents: Search students by name, phone number, or other criteria using Where and string operations like Contains

        //Search students by name
        public IEnumerable<Student> SearchStudentsByName(string Sname)
        {
            return _context.Students.Where( s => s.FName.Contains(Sname)).ToList();
        }

        //Search students by  phone number
        public IEnumerable<Student> SearchStudentsByPhone(string PhoneNumber)
        {
            return _context.Students.Where(s => s.PhoneNum.Contains(PhoneNumber)).ToList();
        }


        //PaginateStudents: Implement pagination for large student data sets. 
    }





}

