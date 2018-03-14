using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class QuestionSetViewModel
    {
        public int Id { get; set; }

        public Student Student { get; set; }

        public Question Question { get; set; }

        public ICollection<Option> Options { get; set; }

    }
}
