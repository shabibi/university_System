using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using university_System.Models;

namespace university_System.Repositories
{
    public class SubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GetAllSubjects: Retrieve all subjects and include the faculty members associated with each subject. 
        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects.Include(s => s.Faculty).ToList();
            
        }

        //GetSubjectById: Fetch a specific subject by ID with navigational properties. 
        public Subject GetSubjectById(int SID)
        {
            return _context.Subjects.Include(s => s.Faculty).FirstOrDefault(e => e.Subject_Id == SID);
        }

        //AddSubject: Add a new subject to the database.
        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        //UpdateSubject: Update details of an existing subject. 
        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        //DeleteSubject: Delete a subject by ID. 

        public void DeleteSubject(int sid)
        {
            var subject = GetSubjectById(sid);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        //GetSubjectsTaughtByFaculty: List subjects taught by a specific faculty member using LINQ.
        public IEnumerable<Subject> GetSubjectsTaughtByFaculty(int FID)
        {
            return _context.Subjects.Include(s => s.Faculty).Where(s => s.FID== FID).ToList();
        }

        //CountSubjects: Use LINQ to get the total number of subjects offered. 
        public int CountSubjects()
        {
            return _context.Subjects.Count();
        }
    }
}
    
