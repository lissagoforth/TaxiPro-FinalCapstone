using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class TestSetViewModel
    {
        public List<Question> Questions { get; set; }

        public IEnumerable<Option> Options { get; set; }

        public IEnumerable<Video> Videos { get; set; }

        public Student Student { get; set; }

        public ApplicationUser User { get; set; }

        public int EventId { get; set; }

        public int TestTypeId { get; set; }
    }
}
