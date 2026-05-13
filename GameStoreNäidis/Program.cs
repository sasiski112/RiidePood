using System;
using System.Collections.Generic;
using System.Linq;

namespace RiidePood
{
    class Program
    {
        static Dictionary<string, double> aktiivsedKaardid = new Dictionary<string, double>();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<IMuugitoode> kataloog = new List<IMuugitoode>()
            {
                new TShirt("Stiilne T-särk", 19.90, "Valge", new Dictionary<string, int>{{ "M", 5 }, { "XS", 2 }}),
                new Puksid("Mustad püksid", 29.99, "Must", new Dictionary<string, int>{{ "L", 6 }}),
                new Jope("Talvejope", 89.99, "Sinine", new Dictionary<string, int>{{ "L", 4 }}),
                new Kleit("Suvekleit", 39.99, "Punane", new Dictionary<string, int>{{ "S", 7 }}),
                new Jalanoud("Tossud", 59.99, "Valge", new Dictionary<string, int>{{ "M", 5 }}),
                new Kinkekaart(20),
                new Kinkekaart(50),
                new Kinkekaart(100)
            };

            while (true)
            {
                List<(IMuugitoode Toode, string Suurus, double Hind)> ostukorv = new List<(IMuugitoode, string, double)>();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== MEIE POOD ===");
                    for (int i = 0; i < kataloog.Count; i++)
                        Console.WriteLine($"{i + 1}. {kataloog[i].KuvaInfo()} | {kataloog[i].ArvutaLopphind():F2} €");

                    Console.WriteLine("\n--- OSTUKORV ---");
                    if (ostukorv.Count == 0) Console.WriteLine("Tühi");
                    else foreach (var item in ostukorv) Console.WriteLine($"- {item.Toode.KuvaInfo()} ({item.Suurus})");

                    Console.Write("\nVali toote number (L - Lõpeta/Maksa, 0 - Välju): ");
                    string sisend = Console.ReadLine().ToUpper();

                    if (sisend == "0") return;
                    if (sisend == "L") break;

                    if (!int.TryParse(sisend, out int valik) || valik < 1 || valik > kataloog.Count)
                    {
                        Console.WriteLine("Viga: Sellist toodet pole! Vajuta suvalist klahvi...");
                        Console.ReadKey();
                        continue;
                    }

                    IMuugitoode toode = kataloog[valik - 1];
                    string valitudSuurus = "Kaart";

                    if (toode is Riideese riie)
                    {
                        if (riie.GetKogus() <= 0) { Console.WriteLine("Toode on otsas!"); Console.ReadKey(); continue; }

                        while (true)
                        {
                            Console.Write($"Vali suurus ({riie.SaadavaltSuurused()}): ");
                            valitudSuurus = Console.ReadLine().ToUpper();
                            if (riie.OnSuurusOlemas(valitudSuurus)) break;
                            Console.WriteLine("Viga: Seda suurust pole või sisend on vale.");
                        }
                    }

                    ostukorv.Add((toode, valitudSuurus, toode.ArvutaLopphind()));
                    Console.WriteLine("Lisatud!");
                    System.Threading.Thread.Sleep(500);
                }

                if (ostukorv.Count == 0) continue;

                double summa = ostukorv.Sum(x => x.Hind);
                Console.WriteLine($"\nKokku: {summa:F2} €");

                while (true)
                {
                    Console.Write("Kas sul on sooduskood? (Jah/Ei): ");
                    string vastus = Console.ReadLine().ToLower();

                    if (vastus == "jah")
                    {
                        Console.Write("Sisesta kood: ");
                        string kood = Console.ReadLine();
                        if (aktiivsedKaardid.ContainsKey(kood))
                        {
                            double allahindlus = aktiivsedKaardid[kood];
                            aktiivsedKaardid.Remove(kood);
                            summa = Math.Max(0, summa - allahindlus);
                            Console.WriteLine($"Soodustus {allahindlus} € rakendatud!");
                        }
                        else Console.WriteLine("Viga: Kood on vale või kasutatud.");
                        break;
                    }
                    else if (vastus == "ei")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Viga: Palun vasta 'Jah' või 'Ei'.");
                    }
                }

                try
                {
                    foreach (var item in ostukorv)
                    {
                        if (item.Toode is Riideese r) r.VahendaKogus(item.Suurus, 1);
                        else item.Toode.VahendaKogus(1);

                        if (item.Toode is Kinkekaart kaart)
                        {
                            aktiivsedKaardid.Add(kaart.Kood, kaart.ArvutaLopphind());
                            Console.WriteLine($"Uus kood: {kaart.Kood} ({kaart.ArvutaLopphind()} €)");
                        }
                    }
                    Console.WriteLine($"\nTEHING ÕNNESTUS! Kokku makstud: {summa:F2} €");
                }
                catch (Exception e) { Console.WriteLine("Viga: " + e.Message); }

                Console.WriteLine("\nVajuta suvalist klahvi uue ostu alustamiseks...");
                Console.ReadKey();
            }
        }
    }
}