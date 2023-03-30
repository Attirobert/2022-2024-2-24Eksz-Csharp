using System;

namespace Sikidomok
{
    public class Negyzet
    {
        private int oldal;

        public double Oldal { get; }

        public Negyzet(int oldal)
        {
            this.oldal = oldal;
        }

        public Negyzet(double oldal1)
        {
            Oldal = oldal1;
        }

        public int getKerulet()
        {
            return this.oldal * 4;
        }

        public int getTerulet()
        {
            return (int)Math.Pow(this.oldal, 2);
        }

        public double getAtlo()
        {
            return Math.Round(Math.Sqrt(2 * Math.Pow(this.oldal, 2)),2);
        }

        public double getTeruletDouble()
        {
            return Math.Pow(Oldal,2);
        }
    }
}
