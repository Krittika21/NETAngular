using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class TestDetailsList
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<UserTypeMap> UserTests { get; set; }

      //  public virtual TestTypeMap TestTypes { get; set; }
    }
}
