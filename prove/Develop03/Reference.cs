/*
Holds the reference of a scripture
*/

public class Reference
{
    private string _reference;
    public Reference(string str)
    {
        _reference = str;
    }

    public override string ToString()
    {
        return _reference;
    }
}