using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models
{
    public class StudentAnswer
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Student> Student { get; set; }

        public virtual ICollection<Option> Option { get; set; }
    }
}
