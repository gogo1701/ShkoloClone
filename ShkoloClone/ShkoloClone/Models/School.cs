namespace ShkoloClone.Models
{
    public class School
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public List<Class> ClassList { get; set; }
        public List<string> Rooms { get; set; }
        public string? SchoolWebsite { get; set; }

        public School(string schoolName, string? schoolWebsite)
        {
            this.SchoolName = schoolName;
            this.ClassList = new List<Class>();
            this.Rooms = new List<string>();
            this.SchoolWebsite = schoolWebsite;
            this.Id = new Guid();
        }


    }
}
