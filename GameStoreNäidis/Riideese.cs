using System;
using System.Collections.Generic;
using System.Linq;

namespace RiidePood
{
    public abstract class Riideese : IMuugitoode
    {
        protected string nimi;
        protected double hind;
        protected string varv;
        protected Dictionary<string, int> suurused;

        public Riideese(string nimi, double hind, string varv, Dictionary<string, int> suurused)
        {
            this.nimi = nimi;
            this.hind = hind;
            this.varv = varv;
            this.suurused = suurused;
        }

        public double GetHind() => hind;

        public virtual int GetKogus() => suurused.Values.Sum();

        public bool OnSuurusOlemas(string suurus)
        {
            return suurused.ContainsKey(suurus) && suurused[suurus] > 0;
        }

        public string SaadavaltSuurused()
        {
            var saadaval = suurused.Where(x => x.Value > 0).Select(x => x.Key);
            return string.Join(", ", saadaval);
        }

        public virtual void VahendaKogus(string suurus, int maugikogus)
        {
            if (!OnSuurusOlemas(suurus)) throw new Exception("Seda suurust ei ole laos!");
            suurused[suurus] -= maugikogus;
        }

        public void VahendaKogus(int kogus)
        {
            var esimeneSaadaval = suurused.FirstOrDefault(x => x.Value > 0).Key;
            if (esimeneSaadaval != null) VahendaKogus(esimeneSaadaval, kogus);
        }

        public virtual string KuvaInfo() => $"{nimi} ({varv}) - Kokku laos: {GetKogus()}";
        public abstract double ArvutaLopphind();
    }
}