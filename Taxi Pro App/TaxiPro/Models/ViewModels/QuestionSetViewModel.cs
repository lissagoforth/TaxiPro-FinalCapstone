using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class QuestionSetViewModel
    {
        public Student Student { get; set; }

        public Question Question { get; set; }

        public IEnumerable<Option> Options { get; set; }

    }
}
