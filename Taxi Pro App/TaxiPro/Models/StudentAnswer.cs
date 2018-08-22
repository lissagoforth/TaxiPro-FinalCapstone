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

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int OptionId { get; set; }
        public Option Option { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
