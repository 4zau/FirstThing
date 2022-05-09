using System;

class Hello
{
    static void Main()
    {
        Console.WriteLine("Hello, World");
        Console.Write("enter a door from 1 to 3: ");
        string door = Console.ReadLine();
        if (door == "1") {
            Console.WriteLine("you died lol");
        } else if (door == "2") {
            Console.WriteLine("you died lol");
        } else if (door == "3") {
            Console.WriteLine("you died lol");
        } else {
            Console.WriteLine("you lived");
        }
    }
}