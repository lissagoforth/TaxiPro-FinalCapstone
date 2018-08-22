using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class VideoViewModel
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public Student Student { get; set; }
        public int EventId { get; set; }
    }
}
