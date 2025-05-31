using System;
using System.Dynamic;
using System.Net;

public class Comment
{
    private string _author;
    private string _text;

    public string GetAuthor()
    {
        return _author;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public void SetText(string text)
    {
        _text = text;
    }
}