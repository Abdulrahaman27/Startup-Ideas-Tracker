using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using startupIdeasTracker;

namespace startupIdeasTracker
{
    class Program
    {
        static List<StartupIdea> ideas = new List<StartupIdea>();
        const string filePath = "ideas.json";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LoadIdeas();

            while (true)
            {
                Console.WriteLine("\nStartup Ideas Tracker");
                Console.WriteLine("1. Add Ideas");
                Console.WriteLine("2. View All Ideas");
                Console.WriteLine("3. Save & Exit");
                Console.WriteLine("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddIdea(); break;
                    case "2": ViewIdeas(); break;
                    case "3": SaveIdeas(); return;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            }
        }


        // Functions
        static void AddIdea()
        {
            var idea = new StartupIdea();
            Console.WriteLine("Idea Name: ");
            idea.Name = Console.ReadLine();

            Console.WriteLine("Problem Solved: ");
            idea.Problem = Console.ReadLine();

            Console.WriteLine("Target Market: ");
            idea.TargetMarket = Console.ReadLine();

            Console.WriteLine("Solution: ");
            idea.Solution = Console.ReadLine();

            Console.WriteLine("Status (Idea/Researching/Validated): ");
            idea.Status = Console.ReadLine();

            Console.WriteLine("Next Steps");
            idea.NextSteps = Console.ReadLine();

            ideas.Add(idea);
            Console.WriteLine("✅ Idea added.");
        }

        static void ViewIdeas()
        {
            if (ideas.Count == 0)
            {
                Console.WriteLine("No Ideas found!");
                return;
            }

            foreach (var idea in ideas)
            {
                Console.WriteLine($"\n--- {idea.Name} ---");
                Console.WriteLine($"Problem: {idea.Problem}");
                Console.WriteLine($"Target Market: {idea.TargetMarket}");
                Console.WriteLine($"Solution: {idea.Solution}");
                Console.WriteLine($"Status: {idea.Status}");
                Console.WriteLine($"Next Steps: {idea.NextSteps}");

            }
        }

        static void SaveIdeas()
        {
            var json = JsonSerializer.Serialize(ideas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("🗃️ Idea Saved");
        }

        static void LoadIdeas()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                ideas = JsonSerializer.Deserialize<List<StartupIdea>>(json) ?? new List<StartupIdea>();
                Console.WriteLine("📂 Ideas loaded.");
            }
        }
    }
}
