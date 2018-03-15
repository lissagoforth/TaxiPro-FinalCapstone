using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }
    }
}
