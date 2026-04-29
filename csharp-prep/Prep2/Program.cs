using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your score: ");
        int score = int.Parse(Console.ReadLine());

        string letterGrade;
        if (score >= 90)
        {
            letterGrade = "A";
        }
        else if (score >= 80)
        {
            letterGrade = "B";
        }
        else if (score >= 70)
        {
            letterGrade = "C";
        }
        else if (score >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if (score < 93 && letterGrade != "F")
        {
            if (score % 10 >= 7)
            {
                letterGrade += "+";
            }
            else if (score % 10 < 3)
            {
                letterGrade += "-";
            }
        }

        bool passing = false;
        if (score >= 70)
        {
            passing = true;
        }

        Console.WriteLine($"Your grade is: {letterGrade}");
        if (passing)
        {
            Console.WriteLine("Good job, you're passing!");
        }
        else
        {
            int toPass = 70 - score;
            Console.WriteLine($"Keep trying, you need to up your grade by {toPass}% to pass.");
        }
    }
}