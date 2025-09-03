using Console_App_Project.Utilities;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Console_App_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagmentApplication Run = new ManagmentApplication();
            Run.Run();
        }
    }
}