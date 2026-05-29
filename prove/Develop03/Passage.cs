/*
Holds the text for a passage as well as a list of Word
objects. Hides words, checks if all words are hidden,
and gets the amount of unhidden words there are left.
*/

public class Passage
{
    private string _passage;
    private static Random _random = new Random();
    private List<Word> _words = [];
    private int _left;
    public Passage(string str)
    {
        _passage = str;
        foreach (string word in _passage.Split(" "))
        {
            _words.Add(new Word(word));
        }
        _left = _words.Count();
    }

    public override string ToString() // Returns the list of words as a string
    {
        return string.Join(" ", _words);
    }

    public void RemoveWords(int removing) // Hides 'int removing' random words
    {
        for (int i = 0; i < removing; i++)
        {
            while (true)
            {
                int random = _random.Next(0, _words.Count);
                if (!_words[random].IsHidden())
                {
                    _words[random].Hide();
                    _left --;
                    break;
                }
            }
        }
    }

    public bool IsEmpty() // Checks if all words are hidden
    {
        if (_left == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetAmountLeft() // Checks how many unhidden words are left
    {
        return _left;
    }
}