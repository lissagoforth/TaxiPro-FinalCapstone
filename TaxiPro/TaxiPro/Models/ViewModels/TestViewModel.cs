﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiPro.Models.ViewModels
{
    public class TestViewModel
    {
        public List<Option> Options { get; set; }
        public int StudentId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
