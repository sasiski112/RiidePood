using System.Collections.Generic;

namespace RiidePood
{
    public class Puksid : Riideese
    {
        public Puksid(string nimi, double hind, string varv, Dictionary<string, int> suurused)
            : base(nimi, hind, varv, suurused) { }

        public override double ArvutaLopphind()
        {
            // Tavahind
            return GetHind();
        }
    }
}