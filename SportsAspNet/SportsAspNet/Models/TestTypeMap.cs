using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class TestTypeMap
    {
        [Key]
        public int ID { get; set; }
        public int TestTypeId { get; set; }
        public int TestId { get; set; }

        [ForeignKey("TestTypeId")]
        public virtual TestType TestTypes { get; set; }
        [ForeignKey("TestId")]
        public virtual TestDetailsList TestDetail { get; set; }
    }
}
