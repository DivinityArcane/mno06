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

            var dist  = 92960000M;        // Distance from the Earth to the Sun.
            var guess = 0M;              // Our guess
            var prec  = 0.1M;            // The precision
            var last  = 0M;              // The last guess
            var res   = 0M;              // Result
            var lres  = 0M;              // Last result
            var sw    = new Stopwatch(); // Stopwatch, for tracking the time it takes.

            sw.Start();

            while (res != dist)
            {
                lres = res;
                res = Pow(guess, 9);
                if (lres != 0 && lres == res) break;
                if (res > dist)
                {
                    guess = last;
                    prec /= +10;
                }
                else
                {
                    last = guess;
                    guess += prec;
                }
            }

            sw.Stop();
            var time = sw.ElapsedMilliseconds;

            Console.WriteLine("Our guess is: {0}", guess);
            Console.WriteLine("Our guess ^ 9 is: {0}", Pow(guess, 9));
            Console.WriteLine("The target ^ 9 is: {0}", dist);
            Console.WriteLine("Precision is: {0}", prec);
            Console.WriteLine("Result is: {0}", guess / 10);
            Console.WriteLine("Guessing took {0} ms", time);
        }

        static decimal Pow (decimal a, int b)
        {
            for (int i = 0; i < b; i++)
                a *= a;
            return a;
        }
    }
}
