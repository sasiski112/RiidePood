using System;

namespace RiidePood
{
    public class Kinkekaart : IMuugitoode
    {
        public string Kood { get; private set; }
        private double vaartus;

        public Kinkekaart(double vaartus)
        {
            this.vaartus = vaartus;
            this.Kood = "GIFT" + new Random().Next(1000, 9999).ToString();
        }

        public double ArvutaLopphind() => vaartus;

        public string KuvaInfo() => $"Kinkekaart väärtusega {vaartus} €";

        public int GetKogus() => 999;
        public void VahendaKogus(int k) {}
    }
}