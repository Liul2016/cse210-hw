using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Ryan", "Inheritance");
        MathAssignment assignment2 = new MathAssignment("Carter", "Mean Value Theorem", "7.2", "1-8");
        WritingAssignment assignment3 = new WritingAssignment("Liul", "Culture of Foreign Countries", "The Significance of Ethiopian Culture");

        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}