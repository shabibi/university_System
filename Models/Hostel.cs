using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university_System.Models
{
    public class Hostel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HostelID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Hostel_Name { get; set; }

        public int No_of_seats { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
