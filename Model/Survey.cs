using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Survey
    {
        public int Id { get; set; }
        public int Flavor { get; set; }
        public int Quality { get; set; }
        public int Frequency { get; set; }
        public int Motivation { get; set; }
        public string? Suggestion { get; set; }
        public int Summary { get; set; }

        public DateTime DateTime { get; set; }
    }
}
