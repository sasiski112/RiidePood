using System.Collections.Generic;

namespace RiidePood
{
    public class Jalanoud : Riideese
    {
        public Jalanoud(string nimi, double hind, string varv, Dictionary<string, int> suurused)
            : base(nimi, hind, varv, suurused) { }

        public override double ArvutaLopphind()
        {
            return GetHind() * 1.1;
        }
    }
}