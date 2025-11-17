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
    }

}
