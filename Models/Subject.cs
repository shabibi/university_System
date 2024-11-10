using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    public class Subject
    {
        [Key]
        public int Subject_Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subject_Name { get; set; }

        [ForeignKey("Faculty")]
        public int? FID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
