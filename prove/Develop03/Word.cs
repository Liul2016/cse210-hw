/*
This class stores a single word and its
status (hidden or not). It also has the
ability to hide the word (replace letters
with the '_' char)
*/

public class Word
{
    private string _word;
    private bool _isHidden;
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public override string ToString() // Return the word
    {
        return _word;
    }

    public void Hide() // Replace all chars with '_'
    {
        int len = _word.Length;
        _word = "";
        for (int i = 0; i < len; i++) {_word += "_";}
        _isHidden = true;
    }

    public bool IsHidden() // Return the status of the word (hidden or not)
    {
        return _isHidden;
    }
}