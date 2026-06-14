/* Reflection
This class walks the user through a reflection activity.
*/

class ReflectionActivity : Activity
{
    private List<string> _RCL_prompts;
    private List<string> _RCL_questions;
    private Random random = new Random();
    public ReflectionActivity(string name, string discription) : base(name, discription)
    {
        _RCL_prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

        _RCL_questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
    }

    /* Starts the reflection activity */
    public void RCL_StartActivity()
    {
        Console.WriteLine(RCL_GetRandomPrompt());
        for (int i = 0; i < (base.RCL_GetTime() / 10); i++)
        {
            Console.Write("Asking guiding question in  ");
            for (int j = 9; j >= 0; j--)
            {
                Console.Write($"\b{j}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"\n\n{RCL_GetRandomQuestion()}");
        }
        Console.Write("Time left before activity completion:  ");
        for (int i = (base.RCL_GetTime() % 10) - 1; i >= 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
    }

    public string RCL_GetRandomPrompt() /* Gets a random prompt from the list of prompts */
    {
        return _RCL_prompts[random.Next(_RCL_prompts.Count())];
    }

        public string RCL_GetRandomQuestion() /* Gets a random question from the list of questions */
    {
        return _RCL_questions[random.Next(_RCL_questions.Count())];
    }
}