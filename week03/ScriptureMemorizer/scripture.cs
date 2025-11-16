using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
{
    Random rand = new Random();
    
    List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());
    
    int toHide = Math.Min(numberToHide, visibleWords.Count);

    for (int i = 0; i < toHide; i++)
    {
        int index = rand.Next(visibleWords.Count);
        visibleWords[index].Hide();
        visibleWords.RemoveAt(index);
    }
}


    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";
        foreach (Word w in _words)
        {
            result += w.GetDisplayText() + " ";
        }
        return result.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}
