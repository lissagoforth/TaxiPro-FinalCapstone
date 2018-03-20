using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class TestResultViewModel
    {
        public List<Option> Answers { get; set; }
        public Student Student { get; set; }
        public ApplicationUser User { get; set; }
        public int Correct { get; set; }
    }
}
