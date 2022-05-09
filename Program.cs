using System;

namespace FirstThing {
    class Hello {
        static void Main() {
            List<Task> tasks = new List<Task>() {
                new Task() {EstimatedTime = 3, Status = Status.NotStarted},
                new Task() {EstimatedTime = 1, Status = Status.InProgress},
                new Task() {EstimatedTime = 0, Status = Status.Done},
                new Task() {EstimatedTime = 2, Status = Status.OnHold},
            };
            int currentTask = 1;
            foreach (Task task in tasks) {
                Console.WriteLine("Current task: " + currentTask.ToString());
                switch (task.Status) {
                    case Status.Done:
                        Console.WriteLine("Already done!");
                        break;
                    case Status.InProgress:
                        Console.WriteLine("Already in progress, time left: " + task.EstimatedTime.ToString());
                        Console.WriteLine("Finishing...");
                        System.Threading.Thread.Sleep(task.EstimatedTime * 1000);
                        Console.WriteLine("Done!");
                        break;
                    case Status.NotStarted:
                        Console.WriteLine("Starting task, time left: " + task.EstimatedTime.ToString());
                        Console.WriteLine("In progress...");
                        System.Threading.Thread.Sleep(task.EstimatedTime * 1000);
                        Console.WriteLine("Done!");
                        break;
                    case Status.OnHold:
                        Console.WriteLine("This task is on hold, skipping...");
                        break;
                }
                Console.WriteLine("Moving onto next task...");
                currentTask++;
            }
            Console.WriteLine("Everything is done!");
        }
    }

    class Task {
        public int EstimatedTime { get; set; }
        public Status Status { get; set; }
    }

    enum Status {
        Done,
        OnHold,
        InProgress,
        NotStarted
    }
}