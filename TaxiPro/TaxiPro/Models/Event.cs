using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public Event()
        {
            DateTime = DateTime.Now;
        }

        public virtual ICollection<ApplicationUser> User { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
