namespace FirstThing;

public class Quiz {
    public static void Execute() {
        Console.WriteLine("Welcome to quiz!");
        Console.WriteLine("What quiz will you take?");
        Console.WriteLine("1. Computer");
        int choice = int.Parse(Console.ReadLine());
        switch (choice) {
            // COMPUTER QUIZ
            case 1:
                BeginQuiz(new[] {
                    "Q1. Is keyboard input or output?",
                    "Q2. Are headphones input or output?",
                    "Q3. What is a monitor?"
                },
                new[,] {
                    { "1. Input", "2. Output", "3. I have no idea" },
                    {"1. Input", "2. Output", "3. Once again, have no idea",},
                    {"1. Keyboard", "2. DVD Player", "3. A monitor?..."}
                },
                new[] { 1, 2, 3});
                break;
        }

        Console.WriteLine("Done!");
    }

    static void BeginQuiz(string[] questions,string[,] answers,int[] codes) {
        DateTime beginTime = DateTime.Now;
        int correctAnswers = 0;

        for (int i = 0; i < questions.Length; i++) {
            Console.WriteLine(questions[i]);
            
            for (int x = 0; x < answers.GetLength(1); x++) {
                Console.WriteLine(answers[i,x]);
            }
            
            Console.Write("Enter your guess: ");
            int guess = int.Parse(Console.ReadLine());
            
            if (guess == codes[i]) {
                correctAnswers++;
                Console.WriteLine("You got it!");
            } else {
                Console.WriteLine("WRONG!");
            }
        }
        Console.WriteLine("Correct answers: {0}, time spent: {1}", correctAnswers, DateTime.Now - beginTime);
        if (correctAnswers == questions.Length) {
            Console.WriteLine("MASTER! Everything right!");
        }
    }

}