using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class TestResultViewModel
    {
        public List<Question> Questions { get; set; }
        public List<Option> Options { get; set; }
        public List<StudentAnswer> Answers { get; set; }
        public Student Student { get; set; }
        public ApplicationUser User { get; set; }
        public int Correct { get; set; }
        public int EventId { get; set; }
    }
}
