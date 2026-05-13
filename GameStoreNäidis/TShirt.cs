using System.Collections.Generic;

namespace RiidePood
{
    public class TShirt : Riideese
    {
        public TShirt(string nimi, double hind, string varv, Dictionary<string, int> suurused)
            : base(nimi, hind, varv, suurused) { }

        public override double ArvutaLopphind() => hind;
    }
}