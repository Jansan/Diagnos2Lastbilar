using System;
using System.Collections.Generic;

namespace Diagnos2Lastbilar
{
    /*
     *
     * Här börjar vi med att skapa Bil-klassen och dess underliggande metoder.
     * Vi arbetar med fyra huvudsakliga egenskaper som får tilldelade värden i sin konstruktor.
     * Vi har även en ToString-override och en Körkortsmetod som kan returnera ett strängvärde.
     * 
     */
    class Bil
    {
        protected string RegistreringsNumber;
        protected string Tillverkare;
        protected int Årtal;
        protected bool Besiktad;

        public Bil(string registreringsNumber, string tillverkare, int årtal, bool besiktad)
        {
            RegistreringsNumber = registreringsNumber;
            Tillverkare = tillverkare;
            Årtal = årtal;
            Besiktad = besiktad;
        }
        public virtual string Körkort()
        {
            return "\t\tDe flesta former av bilar kräver en form av körkort, som minst med B-behörighet.";
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
    /*
     * 
     * Lastbilsklassen är en underklass till Bil-klassen. Den ärver alla egenskaper, men har även en egen privat egenskap i form av Vikt.
     * Värdet motsvarar hur mycket, i ton, som lastbilen är tillåten att dra.
     * Vi har en override som tar över "Körkort"-metoden och gör sin egen utskrift, samt en ViktKontroll-metod som är unik för klassen.
     * 
     */
    class Lastbil : Bil
    {
        private int Vikt;

        public Lastbil(string registreringsNumber, string tillverkare, int årtal, bool besiktad, int vikt) : base(registreringsNumber, tillverkare, årtal, besiktad)
        {
            RegistreringsNumber = registreringsNumber;
            Tillverkare = tillverkare;
            Årtal = årtal;
            Besiktad = besiktad;
            Vikt = vikt;
        }
        public override string Körkort()
        {
            return "\t\tLastbilar kräver variationer C-körkort för att framföras.";
        }
        public string ViktKontroll(int testVikt)
        {
            if (testVikt <= Vikt)
            {
                return "\t\tGodkänd test. Vikten " + testVikt + " av " + Vikt + " kan bäras av " + RegistreringsNumber + ".";
            }
            else
            {
                return "\t\tEj godkänd test. Vikten " + testVikt + " av " + Vikt + " kan ej bäras av " + RegistreringsNumber + ".";
            }
        }
        public override string ToString()
        {
            return base.ToString() 
                + "\n\t\tVikt " + Vikt;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * En grundläggande struktur med en lista som innehåller några grundläggande bilar och lastbilar.
             * 
             */
            List<Bil> bilsLista = new List<Bil>();
            bilsLista.Add(new Lastbil("HTR896", "Toyota", 2005, true, 85));
            bilsLista.Add(new Lastbil("JKL564", "Volvo", 2015, false, 60));
            bilsLista.Add(new Bil("DER256", "Porche", 2018, true));
            bilsLista.Add(new Bil("ABC123", "Ford", 2010, true));
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t* Välkommen till Bilregistret. *\n\n\t\t[1] - Viktkontroll\n\t\t[2] - Samliga enheter\n\t\t[3] - Avsluta");
                Console.Write("\n\t\t* ");
                int result;
                while (!Int32.TryParse(Console.ReadLine(), out result))
                {
                    Console.Write("\n\t\t* ");
                }
                switch (result)
                {
                    case 1:
                        /*
                         * Testar ett inmatat värde mot samtliga Lastbilar som är sparade i listan.
                         */
                        Console.Clear();
                        Console.WriteLine("\n\n\t\t* Var god skriv in ett värde du vill testa mot de registrerade Lastbilarna *");
                        Console.Write("\n\t\t* ");
                        int testVikt;
                        while (!Int32.TryParse(Console.ReadLine(), out testVikt))
                        {
                            Console.Write("\n\t\t* ");
                        }
                        foreach (Bil exempelBil in bilsLista)
                        {
                            if (exempelBil is Lastbil exempleLastbil)
                            {
                                Console.WriteLine("\t\t* " + exempleLastbil.ViktKontroll(testVikt));
                            }
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        /*
                         * Skriver ut samtliga bilars ToString och Körkort. Vi behöver inte särskilja objekten här då samtliga innehåller de här metoderna.
                         */
                        Console.Clear();
                        foreach (Bil referens in bilsLista)
                        {
                            Console.WriteLine("\t\t" + referens + "\n" + referens.Körkort());
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        /*
                         * Avslutar programmet.
                         */
                        isRunning = false;
                        break;
                   
                }
            }

        }
    }
}
