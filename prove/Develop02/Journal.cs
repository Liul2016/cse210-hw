/*This class stores a list of entries. It has
methods to display, save, and load journals.*/

using System;
using System.IO;
using System.Runtime.CompilerServices;

class Journal
{
    public List<string> _entries = new List<string> {}; // List of all the entries in a journal

    // Write all the entries to the console in a human-readable format
    public void DisplayJournal()
    {
        foreach (string entry in _entries)
        {
            string[] split = entry.Split("~~||~~");
            Console.WriteLine($"Date: {split[0]} - {split[1]}");
            Console.WriteLine($"{split[2]}\n");
        }
    }

    // Write all the entries to a file in a easily storable format
    public void SaveJournal(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (string item in _entries)
            {
                outputFile.WriteLine(item);
            }
        }
    }

    // Read all entries from a file and return them to a variable
    public List<string> LoadJournal(string fileName)
    {
        if (File.Exists(fileName)) // Check for file to avoid errors
        {
            // Return the lines in the file as a list if the file exists
            return File.ReadAllLines(fileName).ToList();
        }
        else
        {
            // Return an empty list if the file does not exist
            return new List<string>();
        }
    }
}