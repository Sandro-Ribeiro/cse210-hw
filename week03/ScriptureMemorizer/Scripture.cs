using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

public class Scripture
{
    private Reference _reference;
    private string _text;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
        _words = SplitText(_text);

    }

    public Reference GetReference()
    {
        return _reference;
    }

    public List<Word> SplitText(string text)
    {
        List<Word> words = new List<Word>();
        string[] terms = text.Split(' ');

        foreach (string term in terms)
        {
            string cleanText = term.TrimEnd('.', ',', '!', '?', ';', ':');
            string punctuation = term.Substring(cleanText.Length);

            Word word = new Word();
            word.SetText(cleanText);
            word.SetPunctuation(punctuation);
            words.Add(word);
        }
        return words;
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            List<Word> remainVisible = RemainVisible();
            if (remainVisible.Count > 0)
            {
                int index1 = random.Next(remainVisible.Count);
                Word target = remainVisible[index1];
                int index2 = _words.IndexOf(target);
                _words[index2].Hide();
                hiddenCount++;
            }
            else
            {
                break;
            }

        }
    }

    public string GetDisplayText()
    {
        string sentence = "";

        foreach (Word word in _words)
        {
            sentence += word.GetDisplayText();
        }
        return _reference.GetDisplayText() + " " + sentence.Trim();

    }

    public List<Word> RemainVisible()
    {
        List<Word> remainVisible = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                remainVisible.Add(word);
            }
        }
        return remainVisible;
    }

    public bool IsCompleteHidden()
    {
        bool allHidden = true;
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                allHidden = false;
            }
        }
        return allHidden;
    }

}