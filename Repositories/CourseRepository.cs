using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //GetAllCourses: Retrieve all courses, including students enrolled and faculty handling the course. 
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.Students)
                .Include(c => c.Department).ThenInclude(c => c.Faculties).ToList();
        }

        //GetCourseById: Fetch course details by ID, with related students and faculties. 
        public Course GetCourseById(int CID)
        {
            return _context.Courses.Include(c => c.Students)
                .Include(c => c.Department).ThenInclude(c => c.Faculties)
                    .FirstOrDefault(c => c.CID == CID);
        }

        //AddCourse: Add a new course to the database. 
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        //UpdateCourse: Update existing course details. 
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        //DeleteCourse: Delete a course by ID. 
        public void DeleteCourse(int cid)
        {
            var course = GetCourseById(cid);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        //GetCoursesByDepartment: List courses offered by a specific department. 
        public IEnumerable<Course> GetCoursesByDepartment(int DepartmentId)
        {
            return _context.Courses.Include(e => e.Department).Where(e => e.DepartmentId == DepartmentId).ToList();
        }

        //GetCoursesWithDuration: Filter courses by their duration using LINQ. 
        public IEnumerable<Course> GetCoursesWithDuration(int duration)
        {
            return _context.Courses.Where(e => e.Duration == duration).ToList();
        }

        //PaginateCourses: Implement pagination to handle a large number of courses. 
        public IEnumerable<Course> PaginateCourses(int pageNumber, int pageSize)
        {
            return _context.Courses
                           .OrderBy(c => c.CID)               // Ensure a consistent order
                           .Skip((pageNumber - 1) * pageSize) // Skip the records for previous pages
                           .Take(pageSize)                   // Take only the records for the current page
                           .ToList();                       
        }
    }
}
