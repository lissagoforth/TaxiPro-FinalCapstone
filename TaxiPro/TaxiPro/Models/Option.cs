using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<StudentAnswer> StudentAnswer { get; set; }
    }
}
