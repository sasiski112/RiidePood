using System;
using System.Collections.Generic;
using System.Text;

namespace RiidePood
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Riideese> kataloog = new List<Riideese>()
        {
            new TShirt("Valge T-särk", 15.99, "M", "valge", 10),
            new Puksid("Mustad püksid", 29.99, "L", "must", 5),
            new Jope("Talvejope", 89.99, "XL", "sinine", 3),
            new Kleit("Suvekleit", 39.99, "S", "punane", 7),
            new Jalanoud("Tossud", 59.99, "M", "valge", 4)
        };

            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Console.WriteLine("=== TOOTEKATALOOG ===");

                for (int i = 0; i < kataloog.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {kataloog[i].KuvaInfo()} | Hind: {kataloog[i].ArvutaLopphind():F2} €"
                    );
                }

                Console.WriteLine("\nVali toote number (0 = välju): ");
                int valik;

                if (!int.TryParse(Console.ReadLine(), out valik) || valik < 0 || valik > kataloog.Count)
                {
                    Console.WriteLine("Vale sisend!");
                    Console.ReadKey();
                    continue;
                }

                if (valik == 0)
                    break;

                Riideese valitud = kataloog[valik - 1];

                Console.WriteLine($"Kui palju soovid osta? (Saadaval: {valitud.GetKogus()})");
                int kogus;

                if (!int.TryParse(Console.ReadLine(), out kogus) || kogus <= 0)
                {
                    Console.WriteLine("Vale kogus!");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    double hind = valitud.ArvutaLopphind();
                    double koguhind = hind * kogus;

                    valitud.VahendaKogus(kogus);

                    Console.WriteLine($"Ost õnnestus! Maksid: {koguhind:F2} €");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Viga: " + e.Message);
                }

                Console.WriteLine("\nUuendatud nimekiri:");
                foreach (var ese in kataloog)
                {
                    Console.WriteLine(
                        $"{ese.KuvaInfo()} | Hind: {ese.ArvutaLopphind():F2} €"
                    );
                }

                Console.WriteLine("\nVajuta klahvi jätkamiseks...");
                Console.ReadKey();
            }
        }
    }
}