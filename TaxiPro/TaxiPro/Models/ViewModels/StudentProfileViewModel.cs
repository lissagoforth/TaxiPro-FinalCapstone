using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class StudentProfileViewModel
    {
        public Student Student { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}
