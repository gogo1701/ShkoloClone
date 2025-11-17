using ShkoloClone.Data;

namespace ShkoloClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext application = new();

            application.SaveChanges();
        }
    }
}
