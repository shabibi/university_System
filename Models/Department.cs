using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(30)]
        public string DepartmentName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Exams> Exams { get; set; }
    }
}
