using System;

namespace Prog5
{
    public delegate void NotificationDelegate(string message);

    class Program
    {
        public static void SendEmail(string message)
        {
            Console.WriteLine($"  [EMAIL SERVICE]    Sending Email    : \"{message}\"");
        }

        public static void SendSMS(string message)
        {
            Console.WriteLine($"  [SMS SERVICE]      Sending SMS      : \"{message}\"");
        }

        public static void SendWhatsApp(string message)
        {
            Console.WriteLine($"  [WHATSAPP SERVICE] Sending WhatsApp : \"{message}\"");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 5: Multicast Delegate Notification System");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            Console.WriteLine("--- Broadcasting Notification to All Channels (Email, SMS, WhatsApp) ---");
            NotificationDelegate? notifySystem = SendEmail;
            notifySystem += SendSMS;
            notifySystem += SendWhatsApp;

            string alertMsg = "Your OTP for account login is 482910. Do not share it with anyone.";
            notifySystem(alertMsg);

            Console.WriteLine();
            Console.WriteLine("--- Unsubscribing SMS Channel and Broadcasting New Alert ---");
            notifySystem -= SendSMS;

            string systemUpdateMsg = "Scheduled system update will occur tonight at 02:00 AM UTC.";
            notifySystem?.Invoke(systemUpdateMsg);

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
