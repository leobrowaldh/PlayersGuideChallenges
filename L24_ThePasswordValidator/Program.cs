namespace L24_ThePasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordValidator newPass = new PasswordValidator();
            while (true)
            {
                try
                {
                    Console.Write("Enter a password ");
                    newPass.Password = Console.ReadLine();
                }
                catch (ArgumentException ex) 
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
        }
    }
    class PasswordValidator
    {
        private string _password;
        
        public string Password 
        { 
            get { return _password; }
            set
            {
                if (value.Length < 6 || value.Length > 13)
                    throw new ArgumentException("Password must be between 6 and 13 characters.");

                bool thereIsUpper = false;
                bool thereIsLower = false;
                bool thereIsNumber = false;
                foreach (char letter in value)
                {
                    if (letter == 'T' || letter == '&')
                    {
                        throw new ArgumentException("Password cannot include 'T' or '&'");
                    }
                    if (Char.IsUpper(letter))
                        thereIsUpper = true;
                    if (Char.IsLower(letter))
                        thereIsLower = true;
                    if (Char.IsDigit(letter))
                        thereIsNumber = true;
                }
                if (!thereIsUpper || !thereIsLower || !thereIsNumber)
                    throw new ArgumentException("Password must include at least one Uppercase letter, lowercase letter and number");
                Console.WriteLine("Password set successfull.");
            }

        }
    }
}