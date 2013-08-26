using System;
using System.Diagnostics;

namespace mno06
{
    class Program
    {
        static void Main (string[] args)
        {
            /*  The problem: (From episode 6 of 'Mayoi Neko Overrun!' - 14:23)

                "The height of this multiplied by 10 to the power of 9
                is equal to the distance from the Earth to the Sun."

                The distance from the Earth to the Sun = 92,960,000 miles.
                So, let's calculate this. */

            var dist  = 92960000;        // Distance from the Earth to the Sun.
            var guess = 0D;              // Our guess
            var prec  = 0.00000001D;     // The precision
            var sw    = new Stopwatch(); // Stopwatch, for tracking the time it takes.

            sw.Start();

            while (Math.Pow(guess, 9) < dist)
            {
                guess += prec;
            }

            sw.Stop();
            var time = sw.ElapsedMilliseconds;

            Console.WriteLine("Our guess is: {0}", guess);
            Console.WriteLine("Our guess ^ 9 is: {0}", Math.Pow(guess, 9));
            Console.WriteLine("The target ^ 9 is: {0}", dist);
            Console.WriteLine("Precision is: {0}", prec);
            Console.WriteLine("Result is: {0}", guess / 10);
            Console.WriteLine("Guessing took {0} ms", time);
        }
    }
}
