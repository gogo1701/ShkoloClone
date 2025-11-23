namespace ShkoloClone.Models
{
    public class School
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public List<Class> ClassList { get; set; }
        public List<string> Rooms { get; set; }
        public string? SchoolWebsite { get; set; }

        // Parameterless constructor for JSON deserialization
        public School()
        {
            this.Id = Guid.NewGuid();
            this.SchoolName = string.Empty;
            this.ClassList = new List<Class>();
            this.Rooms = new List<string>();
            this.SchoolWebsite = null;
        }

        public School(string schoolName, string? schoolWebsite)
        {
            this.SchoolName = schoolName;
            this.ClassList = new List<Class>();
            this.Rooms = new List<string>();
            this.SchoolWebsite = schoolWebsite;
            this.Id = Guid.NewGuid();
        }
    }
}
