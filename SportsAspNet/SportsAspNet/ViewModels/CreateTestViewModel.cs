using SportsAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.ViewModels
{
    public class CreateTestViewModel
    {
        public string TestType { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
        public List<UserTypeMap> user { get; set; }
    }
}
