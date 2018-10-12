using System;

namespace TaxiPro.Models
{
    public class EmailSettings
    {
        public String PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public String SecondaryDomain { get; set; }

        public int SecondaryPort { get; set; }

        public String FromEmail { get; set; }

        public String Dir { get; set; }
    }
}
