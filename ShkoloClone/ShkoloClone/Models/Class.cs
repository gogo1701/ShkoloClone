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
        public string Name { get; set; }
        public List<Guid> Students { get; set; }
        public Guid TeacherId { get; set; }

        // Parameterless constructor for JSON deserialization
        public Class()
        {
            this.Id = Guid.NewGuid();
            this.Name = string.Empty;
            this.Students = new List<Guid>();
            this.TeacherId = Guid.Empty;
        }

        public Class(string name, List<Guid> students, Guid teacherId)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Students = students;
            this.TeacherId = teacherId;
        }
        public Class(Guid Id)
        {
            this.Id = Id;
            this.Name = string.Empty;
            Students = new List<Guid>();
        }
    }
}
