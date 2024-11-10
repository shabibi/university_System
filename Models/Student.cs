using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SID { get; set; }

        [Required]
        [MaxLength(20)]
        public String FName { get; set; }

        [MaxLength(20)]
        public String lName { get; set; }

        [Required]
        [MaxLength(100)]
        public String Address { get; set; }

        [Required]
        [MaxLength(10)]
        public String PhoneNum { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        [ForeignKey("Hostel")]
        public int? HostelID { get; set; }
        public Hostel Hostel { get; set; }

        [ForeignKey("Faculty")]
        public int? FID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
