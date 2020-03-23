using System;
using System.Diagnostics;

namespace RaadHetGetal
{
    class Program
    {
        static void Main(string[] args)
        {
            Oplossing deWaarheid = new Oplossing(1,1000);

            Console.WriteLine($"We zoeken een getal tussen {deWaarheid.MinGetal} en {deWaarheid.MaxGetal}.");

            DoorloopMogelijkeOplossingen algoritme1 = new DoorloopMogelijkeOplossingen(deWaarheid);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            int uitkomst = algoritme1.VindHetGetal();
            timer.Stop();

            Console.WriteLine($"DoorloopAlleMogelijkheden heeft er {timer.ElapsedMilliseconds}ms over gedaan.");

            GokRandom algoritme2 = new GokRandom();
            timer.Reset();
            timer.Start();
            uitkomst = algoritme2.VindHetGetal(deWaarheid);
            timer.Stop();

            Console.WriteLine($"Gokramdom heeft er {timer.ElapsedMilliseconds}ms over gedaan.");
            GokRandomMaarNietDubbel algoritme3 = new GokRandomMaarNietDubbel(deWaarheid);
            timer.Reset();
            timer.Start();
            uitkomst = algoritme3.VindHetGetal();
            timer.Stop();

            Console.WriteLine($"Gokrandommaarnietdubbel heeft er {timer.ElapsedMilliseconds}ms over gedaan.");

            HalveerMogelijkeOplossingen algoritme4 = new HalveerMogelijkeOplossingen();
            uitkomst = algoritme4.VindHetGetal(deWaarheid);
            
            Console.WriteLine($"De uitkomst is {uitkomst}");

            Console.ReadLine();
        }
    }
}
