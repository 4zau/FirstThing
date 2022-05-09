using System;
using FirstThing;

namespace FirstThing {
    class Hello {
        public static void Main() {
            bool shouldClose = false;
            while (!shouldClose) {
                Console.WriteLine("What do you want?");
                Console.WriteLine("1. Tasking");
                Console.WriteLine("2. Quiz app");
                Console.WriteLine("3. RPG!");
                Console.WriteLine("0. Quit");
                int choice = 0;
                try {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
                }
                switch (choice) {
                    case 1:
                        Tasking.Execute();
                        break;
                    case 2:
                        Quiz.Execute();
                        break;
                    case 3:
                        RPG.RPG.Execute();
                        break;
                    case 0:
                        shouldClose = true;
                        break;
                }
            }
        }
    }
}