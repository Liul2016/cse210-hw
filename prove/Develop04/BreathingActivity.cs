/* Breathing
This class walks the user through a breathing activity.
*/

using System.ComponentModel;
using System.Runtime.InteropServices.Swift;

class BreathingActivity : Activity
{
    public BreathingActivity(string name, string discription) : base(name, discription){}

    /* Starts the breathing activity */
    public void RCL_StartActivity()
    {
        int intervals = base.RCL_GetTime() / 12;
        if (base.RCL_GetTime() % 12 != 0) {intervals++;}
        base.RCL_SetTime(intervals * 12);

        Console.Write("Breathe in as the circle rises, hold, and then out as it shrinks. Begin in  ");
        for (int j = 5; j >= 0; j--)
        {
            Console.Write($"\b{j}");
            Thread.Sleep(1000);
        }
        Console.Clear();

        for (int i = 0; i < intervals; i++) /* Breathing animation */
        {
            Console.WriteLine("Breathe in");
            Utility.Animate(" .oO", 1, 1000, false);
            Console.WriteLine("\n");

            Console.WriteLine("Hold");
            Utility.Animate("O0", 2, 1000, false);
            Console.WriteLine("\n");

            Console.WriteLine("Breathe out");
            Utility.Animate("Oo. ", 1, 1000, false);
            Console.Clear();
        }
    }
}