using System;
using System.Collections.Generic;
using System.Text;

namespace RiidePood
{
    public class Jope : Riideese
    {
        public Jope(string nimi, double hind, string suurus, string varv, int kogus)
            : base(nimi, hind, suurus, varv, kogus) { }

        public override double ArvutaLopphind()
        {
            return GetHind() + 10;
        }
    }
}
