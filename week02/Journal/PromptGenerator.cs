using System;
using System.Collections.Generic;

public class PromptGenerate
{
    public List<string> _prompts = new List<string>();

    public PromptGenerate()
    {
        _prompts.Add("Did you feel the Spirit today?");
        _prompts.Add("Was there a moment when you felt your divine potential?");
        _prompts.Add("What helped you better understand the Savior’s love?");
        _prompts.Add("Did you see God's hand in your life?");
        _prompts.Add("How did you choose faith over fear?");
        _prompts.Add("Was there a moment when you recognized the Lord’s hand in your life?");
        _prompts.Add("Did something special happen today or did you do something kind for someone else?");
        _prompts.Add("Remember, through small and simple things, the Lord works miracles");
        _prompts.Add("What did you feel while reading the scriptures or praying today?"); 
        _prompts.Add("Good feelings are treasures may one day to do differences in the life´s someone.");
        _prompts.Add("Did someone help strengthen your testimony or did you help someone feel closer to the Savior?");
        _prompts.Add("In what way did you feel like a disciple of Christ today?");
        _prompts.Add("Did something special happen or did you do something kind for someone else?"); 
        _prompts.Add("Remember, through small and simple things, the Lord works miracles");
        _prompts.Add("Some words may to do big difference in the life’s someone at future");
        _prompts.Add("Did someone help strengthen your testimony or did you help someone feel closer to the Savior?"); 
        _prompts.Add("Testimonies grow when they are shared even in writing");
        _prompts.Add("What did you feel while reading the scriptures or praying?"); 
        _prompts.Add("The Spirit speaks quietly. Writing helps preserve what He says");

    }


    Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}