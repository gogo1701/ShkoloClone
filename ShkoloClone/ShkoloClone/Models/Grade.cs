using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Grade
    {
        public double grade {  get; set; }

        public string subject { get; set; }

        public Grade(double grade, string subject)
        {
            this.grade = grade;
            this.subject = subject;
        }
    }
}
