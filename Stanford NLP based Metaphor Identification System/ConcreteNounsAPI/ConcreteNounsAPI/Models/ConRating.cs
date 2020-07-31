using System;
using System.Collections.Generic;

namespace ConcreteNounsAPI.Models
{
    public partial class ConRating
    {
        public string Word { get; set; }
        public string Bigram { get; set; }
        public double ConcM { get; set; }
        public string ConcSd { get; set; }
        public string Unknown { get; set; }
        public int Total { get; set; }
        public string PercentKnown { get; set; }
        public string Subtlex { get; set; }
        public string DomPos { get; set; }
        public string Id { get; set; }
    }
}
