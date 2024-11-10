using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class ExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GetAllExams: List all exams, including the department and students taking the exam. 
        public IEnumerable<Exams> GetAllExams()
        {
            return _context.Exams
                .Include(e => e.Department)
                .ThenInclude(e => e.Courses)
                .ThenInclude(e => e.Students).ToList();
        }

        //GetExamById: Fetch exam details by ID with navigational properties. 
        public Exams GetExamById(string Ecode )
        {
            return _context.Exams.Include(e => e.Department)
                .FirstOrDefault(e => e.Exam_Code == Ecode);
        }

        //AddExam: Add a new exam.
        public void AddExam(Exams exams)
        {
            _context.Exams.Add(exams);
            _context.SaveChanges();
        }

        //UpdateExam: Modify the details of an existing exam.
        public void UpdateExam(Exams exams)
        {
            _context.Exams.Update(exams);
            _context.SaveChanges();
        }

        //DeleteExam: Delete an exam by ID. 
        public void DeleteExam(string ECode)
        {
            var exams = GetExamById(ECode);
            if (exams != null)
            {
                _context.Exams.Remove(exams);
                _context.SaveChanges();
            }
        }

        //GetExamsByDate: Filter exams by a specific date or date range using LINQ. 
        public IEnumerable<Exams> GetExamsByDate(DateTime EDate)
        {
            return _context.Exams.Where(s => s.EDate == EDate ).ToList();
        }

        //GetExamsByStudent: List exams taken by a specific student. 
        public IEnumerable<Exams> GetExamsByStudent(int SID)
        {
            return _context.Exams.Include(e => e.Department)
                .ThenInclude(e => e.Courses)
                .Where(e => e.Department.Courses
                .Any(e => e.Students.Any(e=> e.SID == SID)))
                .ToList();
        }

        //CountExamsByDepartment: Count the number of exams conducted by a specific department. 
        public int CountExamsByDepartment (int departmentId)
        {
            return _context.Exams.Count(e => e.DepartmentId == departmentId); 
        }
    }
}
