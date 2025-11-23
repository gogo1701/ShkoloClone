using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Class
    {
        public Guid Id { get; set; }
        public List<Guid> Students { get; set; }
        public Guid TeacherId { get; set; }

        public Class(List<Guid> students, Guid teacherId)
        {
            this.Students = students;
            this.TeacherId = teacherId;
        }
    }
}
