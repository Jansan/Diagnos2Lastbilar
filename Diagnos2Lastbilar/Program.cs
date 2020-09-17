using System;

namespace Diagnos2Lastbilar
{
    class Bil
    {
        private string RegistreringsNumber;
        private string Tillverkare;
        private int Årtal;
        private bool Besiktad;

        public Bil(string registreringsNumber, string tillverkare, int årtal, bool besiktad)
        {
            RegistreringsNumber = registreringsNumber;
            Tillverkare = tillverkare;
            Årtal = årtal;
            Besiktad = besiktad;
        }
        public override string ToString()
        {
            if (Besiktad)
            {
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                    + "\n\t\t" + RegistreringsNumber
                    + "\n\t\tBesiktad";
            }
            else
            {
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                    + "\n\t\t" + RegistreringsNumber
                    + "\n\t\tObesiktad";
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
