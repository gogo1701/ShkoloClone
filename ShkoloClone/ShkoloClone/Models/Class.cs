using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Class
    {
        private int studentCount;
        public List<Student> students { get; set; }

        public string headTeacherName { get; set; }

        public Class(int studentCount, List<Student> students, string headTeacherName)
        {
            this.studentCount = studentCount;
            this.students = students;
            this.headTeacherName = headTeacherName;
        }
    }
}
