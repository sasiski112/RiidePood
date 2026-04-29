using System;
using System.Collections.Generic;
using System.Text;

namespace RiidePood
{
    public abstract class Riideese : IMuugitoode
    {
        private string nimi;
        private double hind;
        private string suurus;
        private string varv;
        private int kogus;

        public Riideese(string nimi, double hind, string suurus, string varv, int kogus)
        {
            this.nimi = nimi;
            SetHind(hind);
            SetSuurus(suurus);
            LisaKogus(kogus);
            this.varv = varv;
        }

        public void SetHind(double hind)
        {
            if (hind <= 0)
                throw new ArgumentException("Hind peab olema suurem kui 0");

            this.hind = hind;
        }

        public void SetSuurus(string suurus)
        {
            string[] lubatud = { "XS", "S", "M", "L", "XL" };

            if (Array.IndexOf(lubatud, suurus) == -1)
                throw new ArgumentException("Vale suurus");

            this.suurus = suurus;
        }

        public void LisaKogus(int kogus)
        {
            if (kogus < 0)
                throw new ArgumentException("Kogus ei tohi olla negatiivne");

            this.kogus += kogus;
        }

        public void VahendaKogus(int kogus)
        {
            if (kogus < 0)
                throw new ArgumentException("Kogus ei tohi olla negatiivne");

            if (this.kogus - kogus < 0)
                throw new ArgumentException("Laoseis ei tohi minna alla 0");

            this.kogus -= kogus;
        }

        public double GetHind()
        {
            return hind;
        }

        public int GetKogus()
        {
            return kogus;
        }

        public virtual string KuvaInfo()
        {
            return $"{nimi}, suurus: {suurus}, värv: {varv}, kogus: {kogus}";
        }

        public abstract double ArvutaLopphind();
    }
}
