using Console_App_Project.Modles;
using Console_App_Project.Repository;
using Console_App_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_App_Project.Services
{
    internal class UserService
    {
        public readonly string _path = Helper.UserDataFilePathFinder();

        public Repository<User> UserRepository { get; set; } = new Repository<User>();


        public void CreateUser(string userName, string usrerEmail)
        {
            List<User> users = UserRepository.LoadOrCreateListFromJson(_path);

            User user = users.FirstOrDefault(u => u.Email == usrerEmail);
            if (user == null)
            {


                User User = new User(userName, usrerEmail);
                users.Add(User);
                UserRepository.SerializeJson(_path, users);
                User.PrintInfo();
                Helper.Pause();
                Console.Clear();

            }         
        }




        public bool CehckUser(string userName, string usrerEmail)
        {
            List<User> users = UserRepository.LoadOrCreateListFromJson(_path);

            var existingUser = users.FirstOrDefault(u => u.Email == usrerEmail);

            if (existingUser == null)
            {
               
                return true;
            }

            
            if (existingUser.Name == userName)
            {
                return true;
            }

            
            return false;

        }

        public void VerificationSender(string name, string email)
        {
            var userService = new UserService();
            string verifyCode = Helper.GenerateOtpCode();

            Helper.CodeSender(email, verifyCode);

            while (true)
            {

                Helper.ColorfulWriteLine("Please enter the verification code sent to your email:", ConsoleColor.Cyan);
                string UserInput = Helper.GetStringInput();

                if (verifyCode != UserInput)
                {
                    Helper.ColorfulWriteLine("Wrong input!", ConsoleColor.DarkRed);
                }
                else
                    break;
            }
            userService.CreateUser(name, email);

        }

    }
}
