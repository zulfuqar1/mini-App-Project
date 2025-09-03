using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Modles
{
    internal class User: Base.BaseEntity
    {
        public string Name { get; set;}
        public string Email { get; set;}

        public User(string name,string email)
        {
            Name = name;
            Email = email;
        }


        public void PrintInfo() 
        {
            Helper.ColorfulWriteLine("\n╠══════════════════════════════════════════════════════════════════╣",
                ConsoleColor.DarkMagenta);
            Helper.ColorfulWrite("Name:", ConsoleColor.Green);
            Helper.ColorfulWrite( Name, ConsoleColor.Cyan);

            Helper.ColorfulWrite(" | Email:", ConsoleColor.Green);
            Helper.ColorfulWriteLine(Email, ConsoleColor.Cyan);
        }
    }
}
