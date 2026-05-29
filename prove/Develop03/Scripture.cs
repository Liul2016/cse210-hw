/*
This is a class that holds an object from
Reference and Passage and is used by Program
to do everything the program needs to do.
*/

public class Scripture
{
    private Reference _reference;
    private Passage _passage;

    public Scripture(string reference, string passage)
    {
        _reference = new Reference(reference);
        _passage = new Passage(passage);
    }

    public void RemoveWords(int removing) // Hides an amount of words
    {
        _passage.RemoveWords(removing);
    }

    public override string ToString() // Returns the scripture as a string
    {
        return _reference.ToString() + " " + _passage.ToString();
    }

    public bool IsEmpty() // Checks if all the words in the Passage object are hidden
    {
        return _passage.IsEmpty();
    }

    public int GetAmountLeft() // Returns the amount of unhidden words
    {
        return _passage.GetAmountLeft();
    }
}