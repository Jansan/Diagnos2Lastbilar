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
    class Lastbil : Bil
    {
        private int Vikt;

        public Lastbil(string registreringsNumber, string tillverkare, int årtal, bool besiktad, int vikt) : base(registreringsNumber, tillverkare, årtal, besiktad)
        {
            Vikt = vikt;
        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lastbil minLastbil = new Lastbil("ABC123", "Volvo", 1999, true, 64);
            Console.WriteLine(minLastbil);
        }
    }
}
