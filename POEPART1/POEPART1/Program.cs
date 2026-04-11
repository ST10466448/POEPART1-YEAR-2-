using System;
using System.Media;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "Cybersecurity Awareness Bot";

        ShowAsciiArt();
        PlayVoiceGreeting();
        string userName = GetUserName();
        ChatLoop(userName);
    }

    // ===============================
    // ASCII ART HEADER
    // ===============================
    static void ShowAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Added the Cyber Sentinel ASCII Art here
        Console.WriteLine(@"
           _______
          /       \
         |  [0][0]  |   
         |    ^    |       
          \  ===  /
         / -------- \
        / |  S H I | \
       |  |  E L D |  |
        \ |________| /
         \__________/
        ");

        Console.WriteLine("===============================================");
        Console.WriteLine("     CYBERSECURITY AWARENESS BOT");
        Console.WriteLine("===============================================");
        Console.WriteLine(@" 
      [ 🔒 ]   Stay Safe Online   [ 🔒 ]
        ");

        Console.ResetColor();
    }

    // ===============================
    // VOICE GREETING
    // ===============================
    static void PlayVoiceGreeting()
    {
        try
        {
            // Note: Ensure "greeting.wav" is in your /bin/Debug folder
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.PlaySync();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> Voice system offline (greeting.wav not found).");
            Console.ResetColor();
        }
    }

    // ===============================
    // USER NAME INPUT
    // ===============================
    static string GetUserName()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name cannot be empty. Try again: ");
            name = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nWelcome, {name}! 😊");
        Console.ResetColor();

        return name;
    }

    // ===============================
    // CHAT SYSTEM
    // ===============================
    static void ChatLoop(string userName)
    {
        while (true)
        {
            Console.Write("\nYou: ");
            string input = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: I didn’t quite understand that. Could you rephrase?");
                continue;
            }

            if (input == "exit" || input == "quit")
            {
                Console.WriteLine($"Bot: Goodbye {userName}, stay safe online!");
                break;
            }

            Respond(input);
        }
    }

    // ===============================
    // RESPONSE SYSTEM
    // ===============================
    static void Respond(string input)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (input.Contains("how are you"))
        {
            TypeEffect("Bot: My circuits are optimal and my firewall is up! How are you?");
        }
        else if (input.Contains("purpose"))
        {
            TypeEffect("Bot: My purpose is to teach you about cybersecurity and staying safe online.");
        }
        else if (input.Contains("password"))
        {
            TypeEffect("Bot: Use strong passwords (12+ characters) with a mix of types. Consider a Password Manager!");
        }
        else if (input.Contains("phishing"))
        {
            TypeEffect("Bot: Look for 'sense of urgency' or weird sender addresses. When in doubt, don't click!");
        }
        else if (input.Contains("safe browsing"))
        {
            TypeEffect("Bot: Check for HTTPS, avoid public Wi-Fi for banking, and keep your browser updated.");
        }
        else
        {
            TypeEffect("Bot: I'm not sure about that specific topic. Try asking about passwords or phishing!");
        }

        Console.ResetColor();
    }

    // ===============================
    // TYPING EFFECT
    // ===============================
    static void TypeEffect(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(25);
        }
        Console.WriteLine();
    }
}