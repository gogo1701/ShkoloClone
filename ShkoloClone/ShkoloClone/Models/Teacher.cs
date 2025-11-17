using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Teacher
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public List<Class> ClassList { get; set; }
    }
}
