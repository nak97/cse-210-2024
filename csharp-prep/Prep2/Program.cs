using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int user_grade = int.Parse(grade);

        string letter = "";

        if (user_grade >= 90)
        {
            letter = "A";
        }
        else if (user_grade >= 80)
        {
            letter = "B";
        }
        else if (user_grade >= 70)
        {
            letter = "C";
        }
        else if (user_grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (user_grade >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}


