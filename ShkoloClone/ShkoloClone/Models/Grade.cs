using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Grade
    {
        public double Value {  get; set; }

        public string Subject { get; set; }

        public Grade(double value, string subject)
        {
            this.Value = value;
            this.Subject = subject;
        }
    }
}
