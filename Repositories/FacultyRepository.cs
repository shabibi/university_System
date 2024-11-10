using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class FacultyRepository
    {
        private readonly ApplicationDbContext _context;

        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GetAllFaculties: List all faculty members, including the subjects and courses they are associated with. 
        public IEnumerable<Faculty> GetAllFaculties()
        {
            return _context.Faculties.Include(f => f.Subjects)
                .Include(f => f.Department).ThenInclude(f => f.Courses).ToList();
        }

        //GetFacultyById: Fetch a faculty member's complete details by ID, with navigational properties. 
        public Faculty GetFacultyById(int FID)
        {
            return _context.Faculties.Include(f => f.Subjects).Include(f => f.Department)
                .Include(f => f.Students).FirstOrDefault(f => f.FId == FID);
        }

        //AddFaculty: Add a new faculty member. 
        public void AddFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        //UpdateFaculty: Update the details of an existing faculty member. 
        public void UpdateFaculty(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        //DeleteFaculty: Delete a faculty member by ID. 
        public void DeleteFaculty(int fid)
        {
            var faculty = GetFacultyById(fid);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }

        //GetFacultyByDepartment: List faculty members based on their department. 
        public IEnumerable<Faculty> GetFacultyByDepartment(int DepartmentID)
        {
            return _context.Faculties.Include(e => e.Department).Where(e => e.Department.DepartmentId == DepartmentID).ToList();
        }

        //GetFacultyByMobileNumber: Search for faculty members by their mobile number. 
        public IEnumerable<Faculty> GetFacultyByMobileNumber(string PhoneNumber)
        {
            return _context.Faculties.Where(s => s.Mobile_No.Contains(PhoneNumber)).ToList();
        }

        //CalculateAverageSalary: Use LINQ to calculate the average salary of faculty members. 
        public Double CalculateAverageSalary()
        {
            return _context.Faculties.Average(f => f.Salary);
        }

    }
}
