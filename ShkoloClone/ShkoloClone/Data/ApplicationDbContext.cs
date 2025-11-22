using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShkoloClone.Models;

namespace ShkoloClone.Data
{
    public class ApplicationDbContext : JsonDbContext
    {
        public ApplicationDbContext() : base("database.json") { }

        public List<School> Schools => Set<School>("School");
        public List<Class> Classes => Set<Class>("Class");
        public List<Teacher> Teachers => Set<Teacher>("Teacher");
        public List<Student> Students => Set<Student>("Student");
        public List<Grade> Grades => Set<Grade>("Grade");
    }

}
