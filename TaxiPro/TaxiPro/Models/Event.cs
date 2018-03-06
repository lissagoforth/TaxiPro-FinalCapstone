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

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
