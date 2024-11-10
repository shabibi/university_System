using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    [PrimaryKey(nameof(Exam_Code), nameof(DepartmentId))]
    public class Exams
    {
        public string Exam_Code { get; set; }

        public int Room { get; set; }

        public DateTime EDate { get; set; }

        public TimeSpan Time { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
