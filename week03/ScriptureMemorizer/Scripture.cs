using System;
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
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
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