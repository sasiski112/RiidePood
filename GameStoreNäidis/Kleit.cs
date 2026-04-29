using System;
using System.Collections.Generic;
using System.Text;

namespace RiidePood
{
    public class Kleit : Riideese
    {
        public Kleit(string nimi, double hind, string suurus, string varv, int kogus)
            : base(nimi, hind, suurus, varv, kogus) { }

        public override double ArvutaLopphind()
        {
            return GetHind() * 1.05;
            
        }
    }
}
