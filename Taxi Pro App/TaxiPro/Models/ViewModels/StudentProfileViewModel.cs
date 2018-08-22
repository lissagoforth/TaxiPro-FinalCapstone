using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiPro.Models.ViewModels;

namespace TaxiPro.Models.ViewModels
{
    public class StudentProfileViewModel
    {
        public Student Student { get; set; }

        public virtual List<Event> Events { get; set; }

        public Event Event { get; set; }

        public virtual List<CourseViewModel> Results { get; set; }
        
        public CourseViewModel Result { get; set; }
    }
}
