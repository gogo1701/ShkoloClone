namespace ShkoloClone.Models
{
    public class Teacher : AppUser
    {
        public Teacher(string username, string passwordhash, string firstname, string lastname, string phonenumber, string address) : base(username, passwordhash, firstname, lastname, phonenumber, address)
        {
        }

        /*
public Teacher(string userName, string email, string password, string firstName, string lastName, string phone, string? address)
{
   Id = Guid.NewGuid();
   Username = userName;
   PasswordHash = password;
   FirstName = firstName;
   LastName = lastName;
   PhoneNumber = phone;
   Address = address;
}
*/
        public List<Guid> ClassList { get; set; }
    }
}
