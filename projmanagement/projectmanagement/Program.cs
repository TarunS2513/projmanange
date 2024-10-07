using projectmanagement.main;

namespace projectmanagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine(">>> Welcome to the Project Management System ...");

            // Delegate main logic to MainModule.Run() method
            MainModule.Run(args);
        }
    }
}
