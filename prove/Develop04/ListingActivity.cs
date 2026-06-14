/* Listing
This activity walks the user through a listing activity.
*/
class ListingActivity : Activity
{
    private List<string> _RCL_prompts;
    private Random random = new Random();
    public ListingActivity(string name, string discription) : base(name, discription)
    {
        _RCL_prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
        ];
    }

    /* Starts the listing activity */
    public void RCL_StartActivity()
    {
        Console.WriteLine(RCL_GetRandomPrompt());
        Console.Write("Think about this prompt. Beginning in  ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\nBegin listing items.\n");
        DateTime endTime = DateTime.Now.AddSeconds(base.RCL_GetTime()); /* Get the end time */

        int count = 0;
        while (DateTime.Now < endTime) /* Loop until time passes the end time */
        {
            Console.Write(">");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You wrote {count} entries!");
        Thread.Sleep(3000);
    }

        public string RCL_GetRandomPrompt() /* Gets random prompt from list of prompts */
    {
        return _RCL_prompts[random.Next(_RCL_prompts.Count())];
    }
}