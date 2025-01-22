using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

class Validate
{
    public static string ValidateMailID(ref string validEmail)
    {
        while (true)
        {
            Console.Write("Enter your email ID: ");
            string email = Console.ReadLine();

            if (IsValidEmail(email))
            {
                Console.WriteLine("Valid email address.");
                validEmail = email;
                return validEmail;
            }
        }

    }

    public static bool IsValidEmail(string email)
    {
       string pattern = @"^[a-z]+@gmail\.com$";
        return Regex.IsMatch(email, pattern);
    }

    public static string ValidateName( ref string Validname)
    {
         while (true)
        {
            Console.Write("Enter your name ");
            string name = Console.ReadLine();

            if (IsValidName(name))
            {
                Console.WriteLine("Valid User name");
                Validname = name;
                return Validname;
            }
            
        }
    }
    public static bool IsValidName(string name)
    {
       string pattern = @"^(?!.(.).\\1{2})[a-zA-Z][a-zA-Z0-9_-]{3,15}$";
        return Regex.IsMatch(name, pattern);
    }

}