﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.ViewModels
{
    public class AthletesViewModel
    {
        public double? CTDistance { get; set; }
        public double? STTime { get; set; }
        public string Name { get; set; }
        public string fitnessRating { get; set; }
        public int TestId { get; set; }
        public int UserId { get; set; }
    }
}
