using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Console.Clear();
                DisplayMenu();

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddIdea(); break;
                    case "2": ViewIdeas(); break;
                    case "3": SearchIdeas(); break;
                    case "4": SaveIdeas(); return;
                    default: Console.WriteLine("Invalid choice."); break;
                }

            }
        }


        // Functions

        // Display menu

        static void DisplayMenu()
        {
            Console.WriteLine("🌟 Startup Ideas Tracker 🌟");
            Console.WriteLine($"📊 Total Ideas: {ideas.Count}");
            Console.WriteLine("1. Add New Idea");
            Console.WriteLine("2. View All Ideas");
            Console.WriteLine("3. Search Ideas");
            Console.WriteLine("4. Edit Idea");
            Console.WriteLine("5. Delete Idea");
            Console.WriteLine("6. Save & Exit");
            Console.WriteLine("Choose an option: ");
        }

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

        static void SearchIdeas()
        {
            Console.Clear();
            Console.WriteLine("🔍 Search Ideas");
            Console.Write("Enter search term: ");
            var term = Console.ReadLine()?.ToLower(); 

            var results = ideas.Where(i => i.Name.ToLower().Contains(term) || i.Problem.ToLower().Contains(term) || i.Solution.ToLower().Contains(term)).ToList();

            if(results.Count == 0)
            {
                Console.WriteLine("\nNo matching ideas found.");
            }else
            {
                Console.WriteLine($"\nFound {results.Count} matching ideas:");
                foreach (var result in results)
                {
                    Console.WriteLine($"{result.Id}:  {result.Name} ({result.Status})");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


        // Save Ideas Function
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
