using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class DepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GetAllDepartments: Retrieve all departments, including the courses they handle and exams conducted.
        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.Include(d => d.Courses).Include(d => d.Exams).ToList();
        }

        //GetDepartmentById: Fetch department details by ID with navigational properties. 
        public Department GetDepartmentById(int DID)
        {
            return _context.Departments.Include( d => d.Faculties)
                    .Include(d => d.Courses)
                     .Include(d => d.Exams)
                     .FirstOrDefault(e => e.DepartmentId == DID);

        }

        //AddDepartment: Add a new department. 
        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        //UpdateDepartment: Update details of an existing department.
        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        //DeleteDepartment: Delete a department by ID. 
        public void DeleteDepartment(int did)
        {
            var department = GetDepartmentById(did);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        //GetDepartmentsWithCourses: List departments that offer courses using LINQ Join or Include. 
        public IEnumerable<Department> GetDepartmentsWithCourses(int courseId)
        {
            return _context.Departments.Include(d => d.Courses).Where(d => d.Courses.Any(d => d.CID == courseId)).ToList();
        }

        //GetDepartmentNames: Retrieve just the names of all departments using projection in LINQ. 
        public IEnumerable<string> GetDepartmentNames()
        {
            return _context.Departments.Select(d => d.DepartmentName).ToList();
        }


    }
}
