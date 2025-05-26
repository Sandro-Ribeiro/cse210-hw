using System;
using System.Data;
using System.Dynamic;
using System.Runtime.CompilerServices;

public class Reference
{
    private int _id_Ref;
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(int id_Ref, string book, int chapter, int verse)
    {
        _id_Ref = id_Ref;
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(int id_Ref, string book, int chapter, int verse, int endVerse)
    {
        _id_Ref = id_Ref;
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public int GetId()
    {
        return _id_Ref;
    }

    public string GetBook()
    {
        return _book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }


    public string GetDisplayText()
    {
        if (_endVerse != _verse)
        {
            return _book + " " + _chapter + ": " + _verse + "-" + _endVerse;
        }
        else
        {
            return _book + " " + _chapter + ": " + _verse;
        }

    }

}

