using System;
using System.Collections.Generic;

namespace ConcreteNounsAPI.Models
{
    public partial class Concrete
    {
        public string Word { get; set; }
        public double? Bigram { get; set; }
        public double? ConcM { get; set; }
        public double? ConcSd { get; set; }
        public double? Unknown { get; set; }
        public double? Total { get; set; }
        public double? PercentKnown { get; set; }
    }
}
