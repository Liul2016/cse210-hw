/* This class stores a list of prompts and has a method that
gets one of them at random. There is also a meathod used to
format a journal entry into a string used for storing journal
data. This function is used to add formated strings to an
instance of the Journal class. */

using System;
using System.Collections.Generic;

class Entry
{
    public List<string> _prompts = new List<string> // List of prompts to be randomly called
    {
        "What emotion did I feel the most today?",
        "What is one thing I felt gratitude for today?",
        "If I could change one thing about today, what would I change?",
        "What is one activity I did today?",
        "Who is one person I talked to today?",
        "How did I see the hand of the Lord in my life today?"
    };

    // Return a random prompt from the prompt list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count())];
    }

    // Format enties to be added to a journal
    public string GetEntry(string date, string prompt, string userEntry)
    {
        return $"{date}~~||~~{prompt}~~||~~{userEntry}";
    }
}