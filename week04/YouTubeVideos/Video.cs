using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthOfVideo; //Duration in seconds
    private List<Comment> _comments;

    public Video()
    {
        _comments = new List<Comment>();
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthOfVideo()
    {
        return _lengthOfVideo;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public void SetLengthOfVideo(int lenghtOfVideo)
    {
        _lengthOfVideo = lenghtOfVideo;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayComments()
    {
        int widthMax = 80;

        foreach (Comment comment in _comments)
        {
            Console.Write($"\n{comment.GetAuthor()}\n");

            string text = comment.GetText();
            int start = 0;

            while (start < text.Length)
            {
                int remaining = text.Length - start;

                if (remaining <= widthMax)
                {
                    Console.WriteLine(text.Substring(start));
                    break;
                }

                int breakIndex = text.LastIndexOf(' ', start + widthMax, widthMax);

                if (breakIndex > start)
                {
                    Console.WriteLine(text.Substring(start, breakIndex - start));
                    start = breakIndex + 1;
                }
                else
                {
                    int nextSpace = text.IndexOf(' ', start + widthMax);
                    if (nextSpace != -1)
                    {
                        Console.WriteLine(text.Substring(start, nextSpace - start));
                        start = nextSpace + 1;
                    }
                    else
                    {
                        Console.WriteLine(text.Substring(start));
                        break;
                    }
                }

            }
        }
    }
}
