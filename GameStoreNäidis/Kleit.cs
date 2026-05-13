using System.Collections.Generic;

namespace RiidePood
{
    public class Kleit : Riideese
    {
        public Kleit(string nimi, double hind, string varv, Dictionary<string, int> suurused)
            : base(nimi, hind, varv, suurused) { }

        public override double ArvutaLopphind()
        {
            // Hind + 5%
            return GetHind() * 1.05;
        }
    }
}