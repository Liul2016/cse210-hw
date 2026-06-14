/* Utility
This static class holds methods that other classes can use.
 */
static class Utility
{
    /* Animates through a string some amount of times with some delay and can end on the first frame */
    public static void Animate(string frames, int iterations, int delay, bool endAtStart = true)
    {
        for (int i = 0; i < iterations; i++)
        {
            foreach (char j in frames)
            {
                Console.Write($"\b{j}");
                Thread.Sleep(delay);
            }
        }
        if (endAtStart)
        {
            Console.Write($"\b{frames[0]}");
            Thread.Sleep(delay);
        }
    }
}