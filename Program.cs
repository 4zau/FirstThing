using System;

namespace FirstThing {
    class Hello {
        static void Main() {
            bool shouldClose = false;
            while (!shouldClose) {
                Console.WriteLine("What do you want?");
                Console.WriteLine("1. Tasking");
                Console.WriteLine("0. Quit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice) {
                    case 1:
                        Tasking.Execute();
                        break;
                    case 0:
                        shouldClose = true;
                        break;
                }
            }
        }
    }
}