/*
*This was project for .Net fundamental course in sematec.
*In this project, I created a console application that simulates a user sign-up and login system with some mini games.
*Special thanks to my teacher, Mr. Parham Darivishi for his guidance and support throughout the course.
*Mehdi Esmaili - September 2025
*/

using Fudamental_Prj404.Models;
using System;
using System.Threading;

namespace Fudamental_Prj404
{
    internal class Program
    {
        public static void WelcomeMsj()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("███╗   ███╗ ██╗      ██╗ ███╗   ██╗ ███████╗");
            Console.WriteLine("████╗ ████║ ██║      ██║ ████╗  ██║ ██╔════╝");
            Console.WriteLine("██╔████╔██║ ██║      ██║ ██╔██╗ ██║ █████╗  ");
            Console.WriteLine("██║╚██╔╝██║ ██║      ██║ ██║╚██╗██║ ██╔══╝  ");
            Console.WriteLine("██║ ╚═╝ ██║ ███████╗ ██║ ██║ ╚████║ ███████╗");
            Console.WriteLine("╚═╝     ╚═╝ ╚══════╝ ╚═╝ ╚═╝  ╚═══╝ ╚══════╝");
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        Welcome to the MLine System       ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InputsData(User user)
        {
            do // Inputs first name
            {
                Console.Write("Please enter your first name : ");
                string FirstName = Console.ReadLine();
                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName))
                    Console.WriteLine("First name cannot be empty");
                else
                {
                    //first letter to upper case
                    user.FirstName = char.ToUpper(FirstName[0]) + FirstName.Substring(1).ToLower();
                    break;
                }
            } while (true);

            do // Inputs last name
            {
                Console.Write("Please enter your last name : ");
                string LastName = Console.ReadLine();
                if (string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName))
                    Console.WriteLine("Last name cannot be empty");
                else
                {
                    //first letter to upper case
                    user.LastName = char.ToUpper(LastName[0]) + LastName.Substring(1).ToLower();
                    break;
                }
            } while (true);

            do // Inputs email
            {
                Console.Write("Please enter your email : ");
                string Email = Console.ReadLine();
                if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
                    Console.WriteLine("Email cannot be empty");
                else if (!Email.Contains("@") || !Email.Contains(".") || Email.StartsWith("@") || Email.StartsWith("."))
                    Console.WriteLine("Email is not valid");
                else
                {
                    user.Email = Email;
                    break;
                }
            } while (true);

            do // Inputs phone number
            {
                Console.Write("Please enter your phone number : ");
                string PhoneNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrWhiteSpace(PhoneNumber))
                    Console.WriteLine("Phone number cannot be empty");
                else if (PhoneNumber.Length != 11 || !PhoneNumber.StartsWith("09") || !long.TryParse(PhoneNumber, out _))
                    Console.WriteLine("Phone number is not valid");
                else
                {
                    user.PhoneNumber = PhoneNumber;
                    break;
                }
            } while (true);

            do // Inputs National Code
            {
                Console.Write("Please enter your national code : ");
                string NationalCode = Console.ReadLine();
                if (string.IsNullOrEmpty(NationalCode) || string.IsNullOrWhiteSpace(NationalCode))
                    Console.WriteLine("National code cannot be empty");
                else if (NationalCode.Length != 10 || !long.TryParse(NationalCode, out _))
                    Console.WriteLine("National code is not valid");
                else
                {
                    user.NationalCode = NationalCode;
                    break;
                }
            } while (true);

            do //Inputs Birth Date
            {
                Console.Write("Please enter your birth date (yyyy/mm/dd) : ");
                string BirthDate = Console.ReadLine();
                if (string.IsNullOrEmpty(BirthDate) || string.IsNullOrWhiteSpace(BirthDate))
                    Console.WriteLine("Birth date cannot be empty");
                else if (!DateTime.TryParse(BirthDate, out DateTime birthDate))
                    Console.WriteLine("Birth date is not valid");
                else
                {
                    user.BirthDate = birthDate;
                    break;
                }
            } while (true);

        }
        public static void SetUsernameAndPassword(User user)
        {
            Console.WriteLine("Now, you have to set your username and password");
            do // Inputs username
            {
                Console.Write("Please enter your username : ");
                string UserName = Console.ReadLine();
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
                    Console.WriteLine("Username cannot be empty");
                else if (UserName.Length < 5)
                    Console.WriteLine("Username must be at least 5 characters");
                else
                {
                    user.UserName = UserName;
                    break;
                }
            } while (true);
            do // Inputs password
            {
                Console.Write("Please enter your password : ");
                string Password = Console.ReadLine();
                if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
                    Console.WriteLine("Password cannot be empty");
                else if (Password.Length < 8)
                    Console.WriteLine("Password must be at least 8 characters");
                else if (!Password.Any(char.IsUpper))
                    Console.WriteLine("Password must contain at least one uppercase letter");
                else if (!Password.Any(char.IsLower))
                    Console.WriteLine("Password must contain at least one lowercase letter");
                else if (!Password.Any(char.IsDigit))
                    Console.WriteLine("Password must contain at least one digit");
                else
                {
                    user.Password = Password;
                    break;
                }
            } while (true);
        }
        public static void ShowUserInfo(User user)
        {
            Console.WriteLine("Your information:");
            Console.WriteLine($"Full Name: {user.FullName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone Number: {user.PhoneNumber}");
            Console.WriteLine($"National Code: {user.NationalCode}");
            Console.WriteLine($"Birth Date: {user.BirthDate.ToShortDateString()}");
            Console.WriteLine($"Age: {user.Age}");
        }
        public static void GuessNumberGame()
        {
            /*In this game one number will be choosed randomly from 1 to 100 and user must guess
             * and find the number with help (higher or lower) and user has 10 chance to guess. */

            Console.WriteLine("<<< Welcome to Guessing The Number game >>>");
            Console.WriteLine("In this game you have to guess the random number from 1 to 100");
            Console.WriteLine("You only have 10 chance, Let's go");
            Console.WriteLine("<--------------------------------------------------->");

            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, 101);

            int UserGuess = 0;
            for (int i = 1; i <= 10; i++)
            {
                do
                {
                    Console.Write($"Enter your {i} guess : ");
                    UserGuess = int.Parse(Console.ReadLine());

                    if (UserGuess > 100 || UserGuess < 1)
                        Console.WriteLine("The number must be between 1 to 100");
                    else
                        break;
                } while (true);

                if (UserGuess > RandomNumber)
                    Console.WriteLine("Lower");
                else if (UserGuess < RandomNumber)
                    Console.WriteLine("Higher");
                else
                {
                    Console.WriteLine($"YOU WIN, The number was {RandomNumber}!");
                    return;
                }
            }
            Console.WriteLine($"You lost, The number was {RandomNumber} :(");
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            WelcomeMsj();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<<< You have to sign up in advance >>>");
            Console.WriteLine("Please fill in the following information to sign up:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------------------------------------------------->");
            Console.ResetColor();
            User user = new User();

            InputsData(user);                //      Input all user data
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------------------------------------------------->");
            Console.ResetColor();
            ShowUserInfo(user);              //     Show user information
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------------------------------------------------->");
            Console.ResetColor();
            SetUsernameAndPassword(user);    // Setting Username and Password
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<--------------------------------------------------->");
            Console.ResetColor();
            Console.WriteLine("Just a seconds ");

            char[] spinner = { '/', '|', '\\', '-' };
            Console.Write("Loading ");

            for (int i = 0; i < 30; i++) // Adjust loop count for duration
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200); // Delay in milliseconds
                Console.Write("\b"); // Move cursor back to overwrite
            }

            Console.WriteLine("Done!");

            Console.WriteLine("You have successfully signed up!");
            Console.WriteLine("Now, you can log in with your username and password");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("███╗   ███╗ ██╗      ██╗ ███╗   ██╗ ███████╗");
            Console.WriteLine("████╗ ████║ ██║      ██║ ████╗  ██║ ██╔════╝");
            Console.WriteLine("██╔████╔██║ ██║      ██║ ██╔██╗ ██║ █████╗  ");
            Console.WriteLine("██║╚██╔╝██║ ██║      ██║ ██║╚██╗██║ ██╔══╝  ");
            Console.WriteLine("██║ ╚═╝ ██║ ███████╗ ██║ ██║ ╚████║ ███████╗");
            Console.WriteLine("╚═╝     ╚═╝ ╚══════╝ ╚═╝ ╚═╝  ╚═══╝ ╚══════╝");

            Console.WriteLine("Singing in");

            do // login username
            {
                Console.Write("Enter your Username : ");
                string InputUserName = Console.ReadLine();
                if (string.IsNullOrEmpty(InputUserName))
                    Console.WriteLine("Username cannot be null or empty");
                if (InputUserName != user.UserName)
                    Console.WriteLine("No username found...");
                else
                    break;
            } while (true);

            Console.WriteLine("User name Founded!");

            do // login password
            {
                Console.Write("Enter yout Password : ");
                string InputPassword = Console.ReadLine();
                if (string.IsNullOrEmpty(InputPassword))
                    Console.WriteLine("Password cannot be null or empty");
                if (InputPassword != user.Password)
                    Console.WriteLine("Wrong Password");
                else
                    break;
            }while(true);

            Console.WriteLine($"Hello {user.FirstName}!");
            Console.WriteLine("Loading ");

            Console.Write("Loading ");

            for (int i = 0; i < 30; i++) // Adjust loop count for duration
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200); // Delay in milliseconds
                Console.Write("\b"); // Move cursor back to overwrite
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            GuessNumberGame();
        }
    }
}
