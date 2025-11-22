using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class School
    {
        private int studentCount;
        private int teacherCount;
        private string headMasterName;
        
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public List<Guid> ClassList { get; set; }

        public List<string> roomNames { get; set; }

        public string schoolUrl { get; set; }

        public School(string headMasterName, string schoolName, List<Guid> classList, List<string> roomNames, string schoolUrl)
        {
            studentCount = 0;
            teacherCount = 0;
            this.headMasterName = headMasterName;
            this.SchoolName = schoolName;
            this.ClassList = classList;
            this.roomNames = roomNames;
            this.schoolUrl = schoolUrl;
        }


    }
}
