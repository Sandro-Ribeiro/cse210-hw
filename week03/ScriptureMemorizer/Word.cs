using System;
using System.Runtime.CompilerServices;

public class Word
{
    private string _text;
    private string _punctuation;
    private bool _isHidden;

    public Word()
    {
        _isHidden = false;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public void SetPunctuation(string punctuation)
    {
        _punctuation = punctuation;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string newText = new string('_', _text.Length);
            return newText + _punctuation + " ";
        }
        else
        {
            return _text + " ";
        }
    }
}