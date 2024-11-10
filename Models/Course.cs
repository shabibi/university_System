using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    public class Course
    {
        [Key]
        public int CID { get; set; }

        [Required]
        [MaxLength(30)]
        public string CName { get; set; }

        [Range(1, 6)]
        public int Duration { get; set; }

        public virtual ICollection<Student> Students { get; set; }


        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
