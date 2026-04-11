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
        TypeEffect("Bot: I'm operating at full capacity and ready to help! My main goal is to assist you in understanding cybersecurity and protecting yourself online.");
    }
    else if (input.Contains("purpose"))
    {
        TypeEffect("Bot: My purpose is to educate users about cybersecurity risks and best practices. I help you understand how to protect your personal data, avoid scams, and stay safe while browsing the internet.");
    }
    else if (input.Contains("password"))
    {
        TypeEffect("Bot: Strong passwords are essential for protecting your accounts. You should use a combination of uppercase and lowercase letters, numbers, and special characters. Avoid using personal information like your name or birthdate, and never reuse passwords across multiple accounts. Consider using a password manager for extra security.");
    }
    else if (input.Contains("phishing"))
    {
        TypeEffect("Bot: Phishing is a type of cyber attack where attackers trick you into revealing sensitive information such as passwords or banking details. These attacks often come through emails or messages that look legitimate. Always verify the sender, avoid clicking suspicious links, and never provide personal information unless you are sure the source is trustworthy.");
    }
    else if (input.Contains("safe browsing"))
    {
        TypeEffect("Bot: Safe browsing means being cautious about the websites you visit and the links you click. Always check for HTTPS in the website URL, avoid downloading files from untrusted sources, and keep your browser and antivirus software up to date to protect against threats.");
    }
    else if (input.Contains("malware"))
    {
        TypeEffect("Bot: Malware is malicious software designed to harm your device or steal your data. It can come from unsafe downloads, email attachments, or infected websites. To stay protected, install antivirus software, avoid suspicious downloads, and keep your system updated.");
    }
    else if (input.Contains("vpn"))
    {
        TypeEffect("Bot: A VPN, or Virtual Private Network, helps protect your privacy online by encrypting your internet connection. It is especially useful when using public Wi-Fi, as it prevents hackers from intercepting your data.");
    }
    else
    {
        TypeEffect("Bot: I didn’t quite understand that. You can ask me about topics like passwords, phishing, malware, VPNs, or safe browsing.");
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
