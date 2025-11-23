using ShkoloClone.Data;
using ShkoloClone.User_Interface;

namespace ShkoloClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext application = new();

            application.SaveChanges();

            LogInOrSignUpUI.LogInUI();

        }
    }
}
