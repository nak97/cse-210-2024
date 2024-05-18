using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.Run();
    }
}

class Journal
{
    private JournalEntry journalEntry = new JournalEntry();
    private PromptGenerator promptGenerator = new PromptGenerator();

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Write a journal entry");
            Console.WriteLine("2. Display previous journal entry");
            Console.WriteLine("3. Load a journal entry from another file");
            Console.WriteLine("4. Save the current journal entry to a file");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journalEntry.WriteEntry(promptGenerator.GeneratePrompt());
                    break;
                case "2":
                    journalEntry.DisplayEntry();
                    break;
                case "3":
                    journalEntry.LoadEntry();
                    break;
                case "4":
                    journalEntry.SaveCurrentEntry();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}

class PromptGenerator
{
    private string[] prompts = 
    {
        "What was the highlight of your day?",
        "What did you learn today?",
        "How are you feeling right now?",
        "Describe a memorable moment from today.",
        "What are you grateful for today?"
    };

    public string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}

class JournalEntry
{
    private string currentEntry;

    public void WriteEntry(string prompt)
    {
        Console.WriteLine("Journal Prompt: " + prompt);
        Console.WriteLine("Write your journal entry:");
        currentEntry = Console.ReadLine();
    }

    public void DisplayEntry()
    {
        if (File.Exists("journal.txt"))
        {
            string entry = File.ReadAllText("journal.txt");
            Console.WriteLine("Previous Journal Entry:");
            Console.WriteLine(entry);
        }
        else
        {
            Console.WriteLine("No previous journal entry found.");
        }
    }

    public void LoadEntry()
    {
        Console.WriteLine("Enter the path of the file to load:");
        string filePath = Console.ReadLine();
        if (File.Exists(filePath))
        {
            currentEntry = File.ReadAllText(filePath);
            Console.WriteLine("Loaded Journal Entry:");
            Console.WriteLine(currentEntry);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void SaveCurrentEntry()
    {
        if (string.IsNullOrEmpty(currentEntry))
        {
            Console.WriteLine("No current journal entry to save.");
        }
        else
        {
            Console.WriteLine("Enter the file path to save the journal entry:");
            string filePath = Console.ReadLine();
            try
            {
                File.WriteAllText(filePath, currentEntry);
                Console.WriteLine("Journal entry saved to file: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving journal entry: " + ex.Message);
            }
        }
    }
}