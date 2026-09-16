delegate void Greet(string name);

static class Q1_DelegateIntro
{

    static void SayHello(string name)
        => Console.WriteLine($"  Hello, {name}! Welcome to delegates.");

    static void SayGoodbye(string name)
        => Console.WriteLine($"  Goodbye, {name}! See you soon.");

    public static void Run()
    {
        Banner("Q1 – Delegate: Definition & Syntax");

        Greet greet1 = new Greet(SayHello);
        greet1("Alice");

        Greet greet2 = SayGoodbye;
        greet2.Invoke("Bob");

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("  Key Points:");
        Console.WriteLine("  • delegate keyword creates a new type.");
        Console.WriteLine("  • The delegate type must match the method signature exactly.");
        Console.WriteLine("  • Delegates are reference types; they live on the heap.");
        Console.WriteLine("  • They are the foundation of events and callbacks in C#.");
        Console.ResetColor();
    }

    static void Banner(string title)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  +- {title} -+");
        Console.ResetColor();
    }
}
