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
