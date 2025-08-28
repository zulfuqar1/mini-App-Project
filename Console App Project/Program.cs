using Console_App_Project.Utilities;
using System.Linq.Expressions;

namespace Console_App_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string input = null;
            bool result = false;

            while (!result)
            {
                Helper.ShowMenu();

                input = Console.ReadLine();
                result = int.TryParse(input, out choice);
                if (!result)
                {

                }


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;
                    case 2:
                        Console.WriteLine("1");
                        break;
                    case 3:
                        Console.WriteLine("1");
                        break;
                    case 4:
                        Console.WriteLine("1");
                        break;
                    case 5:
                        Console.WriteLine("1");
                        break;
                    case 6:
                        Console.WriteLine("1");
                        break;
                    case 7:
                        Console.WriteLine("1");
                        break;
                }




            }

        }
    }
}
