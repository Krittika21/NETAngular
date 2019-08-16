using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class UserTypeMap
    {
        [Key]
        public int ID { get; set; }
        public double? CTDistance { get; set; }
        public double? STTime { get; set; }
       // public string Name { get; set; }
        public string FitnessRating { get; set; }

        public int TestId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TestId")]
        public virtual TestDetailsList TestDetail { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
