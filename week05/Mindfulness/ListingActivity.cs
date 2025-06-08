public class ListingActivity:Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();

    public ListingActivity():base()
    {
        base.SetName("Breathing Activity");
        base.SetDescripton(
            "This activity will help you relax by walking your " +
            "through breathing in and out slowly. \n" +
            "Clear your mind and focus on your breathing."
            );

        _prompts.AddRange(new[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

    }

    public void Run()
    {


    }

    public void GetRandomPrompt()
    {

    }

    public List<string> GetListFromUser()
    {
        List<string> listFromUser = new List<string>();
        return listFromUser;
        
    }
}