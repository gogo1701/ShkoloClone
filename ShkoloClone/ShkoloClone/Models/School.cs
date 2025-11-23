namespace ShkoloClone.Models
{
    public class School
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public List<Guid> ClassList { get; set; }
        public List<string> Rooms { get; set; }
        public string SchoolWebsite { get; set; }

        public School(string schoolName, List<Guid> classList, List<string> roomNames, string schoolWebsite)
        {
            this.SchoolName = schoolName;
            this.ClassList = classList;
            this.Rooms = roomNames;
            this.SchoolWebsite = schoolWebsite;
        }


    }
}
