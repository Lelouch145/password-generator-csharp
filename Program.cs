using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("--- Password Generator ---");

        // Hämtar lösenordets längd från användaren
        int length = GetPasswordLength();
        // Frågar användaren om den vill inkludera siffror i sin lösenord
        bool includeNumbers = AskYesNo("Include numbers? (y/n): ");
        // Frågar användaren om den vill inkludera speciala tecken i sin lösenord
        bool includeSpecialChars = AskYesNo("Include special characters? (y/n): ");

        string password = GeneratePassword(length, includeNumbers, includeSpecialChars);

        Console.WriteLine($"\nGenerated password: {password}");
    }


    static int GetPasswordLength()
    {
        Console.Write("How long should the password be: ");

        // Läser användarens svar
        string userInput = Console.ReadLine();

        //Försöker konvertera userInput till ett heltal
        // out int length betyder att om konverteringen lyckas sparas numret i variabeln length
        if (int.TryParse(userInput, out int length) && length > 0)
        {
            // Om användaren skrev ett giltigt nummer större än 0 returneras längden
            return length;
        }

        Console.WriteLine("Please enter a valid number greater than 0. ");

        // Metoden körs igen tills användaren skriver ett giltigt nummer
        return GetPasswordLenght();
    }

    // denna metod används för frågor där användaren ska svara y eller n
    static bool AskYesNo(string message)
    {
        // Skriver ut frågan med hjälp av parametrar
        Console.Write(message);

        // Läser användarens svar och gör om det till små bokstäver
        string answer = Console.ReadLine().ToLower();

        if (answer == "y")
        {
            return true;
        }
        else if (answer == "n")
        {
            return false;
        }

        Console.WriteLine("Please enter y or n. ");

        // metoden kärs igen tills användaren skriver ett giltigt svar
        return AskYesNo(message);
    }

    static string GeneratePassword(int length, bool includeNumbers, bool includeSpecialChars)
    {
        // Alla bokstäver som kan användas i lösenordet
        string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Alla siffror som kan användas
        string numbers = "0123456789";

        // Specialtecken som kan användas
        string specialChars = "!@#$%^&*()-_=+<>?";

        // Börjar med att endast använda bokstäver
        string availableChars = letters;

        // Om användaren vill inkludera siffror läggs de till
        if (includeNumbers)
        {
            availableChars += numbers;
        }

        // Om användaren vill inkludera specialtecken läggs de till
        if (includeSpecialChars)
        {
            availableChars += specialChars;
        }

        // Skapar ett Random-objekt för att generera slumpmässiga tecken
        Random random = new Random();

        // Variabeln kommer att hålla färdiga lösenordet
        string password = "";

        // loopen kör tills den når lösenordets antal tecken
        for (int i = 0; i < length; i++)
        {
            // Väljer slumpmässigt index från stängen med tillåtna tecken
            int index = random.Next(availableChars.Length);

            // lägger till tecknet från den positionen i lösenordet
            password += availableChars[index];
        }

        // Returnerar det färdiga lösenordet
        return password;

    }



}