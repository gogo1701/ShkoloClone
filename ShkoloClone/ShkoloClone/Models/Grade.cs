using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Grade
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public double Value {  get; set; }
        public string Subject { get; set; }

        // Parameterless constructor for JSON deserialization
        public Grade()
        {
            this.Id = Guid.NewGuid();
            this.StudentId = Guid.Empty;
            this.TeacherId = Guid.Empty;
            this.Value = 0;
            this.Subject = string.Empty;
        }

        public Grade(Guid studentId, Guid teacherId, double value, string subject)
        {
            this.StudentId = studentId;
            this.TeacherId = teacherId;
            this.Value = value;
            this.Subject = subject;
            Id = Guid.NewGuid();
        }
    }
}
