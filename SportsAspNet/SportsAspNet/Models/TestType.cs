using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class TestType
    {
        [Key]
        public int ID { get; set; }
        public string TestName { get; set; }
        //public virtual ICollection<TestTypeMap> TestTypes { get; set; }
    }
}
