using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Models
{
    public class ListUser
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime DateJoined { get; set; }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
