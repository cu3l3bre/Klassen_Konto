using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    class Konto
    {
        //  Attribute
        private int nummer;
        private string vorname;
        private string nachname;
        private double stand;
        private int pin;


        // Konstruktoren
        public Konto()
        {
            this.nummer = 0;
            this.vorname = "Max";
            this.nachname = "Mustermann";
            this.stand = 0.0;
            this.pin = 0;
        }

        public Konto(int nummer, string vorname, string nachname, int stand, int pin)
        {
            this.nummer = nummer;
            this.vorname = vorname;
            this.nachname = nachname;
            this.stand = stand;
            this.pin = pin;
        }


        // Properties
        public int Kontonummer
        {
            get { return nummer; }
            set { nummer = value; }
        }

        public double Kontostand
        {
            get { return stand; }
            set { stand = value; }
        }

        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }

        public int Pin
        {
            get { return pin; }
        }



        // Methoden
        public void einzahlen(double betrag)
        {
            stand += betrag;
        }

        public void abheben(double betrag)
        {
            stand -= betrag;
        }


        public void zeigeKontostand()
        {
            Console.WriteLine("Akuteller Konstandstand am {0} ist {1}", DateTime.Now, this.stand);
        }

        public void zeigeKontodaten()
        {
            Console.WriteLine();
            Console.WriteLine("Kontonummer: {0}", this.nummer);
            Console.WriteLine("Vorname:     {0}", this.vorname);
            Console.WriteLine("Nachname:    {0}", this.nachname);
            Console.WriteLine("Kontostand:  {0}", this.stand);
            Console.WriteLine();
        }

    }
}
