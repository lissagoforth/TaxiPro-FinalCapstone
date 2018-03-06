using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TaxiPro.Models
{
    public class TestType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
