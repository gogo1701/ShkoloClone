namespace ShkoloClone.Models
{
    public class Student : AppUser
    {
        public Student(string username, string passwordhash, string firstname, string lastname, string phonenumber, string address) : base(username, passwordhash, firstname, lastname, phonenumber, address)
        {
        }

        /*
public Student(string username, string email, string password, string firstName, string lastName,string phone, string? address)
{
   Id = Guid.NewGuid();
   Username = userName;
   PasswordHash = password;
   FirstName = firstName;
   LastName = lastName;
   PhoneNumber = phone;
   Address = address;
   Grades = new List<Grade>();
}
*/
        public List<Guid> Grades { get; set; }
    }
}
