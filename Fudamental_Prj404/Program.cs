using Fudamental_Prj404.Models;

namespace Fudamental_Prj404
{
    internal class Program
    {
        public static void WelcomeMsj()
        {
            Console.WriteLine("Welcome to the MLine system");
        }

        public static void InputsData (User user)
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
        static void Main(string[] args)
        {
            WelcomeMsj();

            Console.WriteLine("<<< You have to sign up in advance >>>");
            Console.WriteLine("Please fill in the following information to sign up:");
            Console.WriteLine("<--------------------------------------------------->");
            User user = new User();

            InputsData(user); // Input all user data

            // Double check the inputs with user
            Console.WriteLine("<--------------------------------------------------->");
            Console.WriteLine("Accepted, Let's double check the result");
            Console.WriteLine("<--------------------------------------------------->");
            Console.WriteLine($"First name : {user.FirstName}");
            Console.WriteLine($"Last name : {user.LastName}");
            Console.WriteLine($"National code : {user.NationalCode}");
            Console.WriteLine($"Email : {user.Email}");
            Console.WriteLine($"Phone number : {user.PhoneNumber}");
            Console.WriteLine($"Birth date : {user.BirthDate.ToShortDateString()}, You are {user.Age} years old");
            Console.WriteLine("<--------------------------------------------------->");

        }
    }
}
