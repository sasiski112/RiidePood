using System.Collections.Generic;

namespace RiidePood
{
    public class Jope : Riideese
    {
        public Jope(string nimi, double hind, string varv, Dictionary<string, int> suurused)
            : base(nimi, hind, varv, suurused) { }

        public override double ArvutaLopphind()
        {
            return GetHind() + 10;
        }
    }
}