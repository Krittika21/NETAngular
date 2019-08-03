using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeOfUsers UserType { get; set; }
        public virtual ICollection<UserTypeMap> UserTest { get; set; }
    }
}
