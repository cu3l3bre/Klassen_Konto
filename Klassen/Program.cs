using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen
{
    class Program
    {
        static void Main(string[] args)
        {

            Konto[] konten = new Konto[3];
            Konto kontoTemp = new Konto();

            konten[0] = new Konto(111,"Max","Mustermann",100,1);
            konten[1] = new Konto(222, "Maxine", "Musterfrau", 200, 2);
            konten[2] = new Konto(333, "Daniel", "Himself", 300, 3);


            //konten[0].zeigeKontodaten();
            //konten[1].zeigeKontodaten();
            //konten[2].zeigeKontodaten();

            string benutzerEingabe = "";
            bool eingabeOK = false;


            bool kontonummerBekannt = false;
            bool pinOK = false;

            int kontonummer = 0;
            int pin = 0;
            int menuAuswahl = 0;
            double betrag = 0.0;

            int maxVersuche = 3;
            int anzahlVersuche = 0;

            bool abbruch = false;
            bool MenuVerlassen = false;


            while (!kontonummerBekannt)
            {
                
                eingabeOK = false;
                while (!eingabeOK)
                {
                    Console.Clear();
                    Console.Write("Bitte melden Sie sich mit ihrer Kontonummer an: ");
                    benutzerEingabe = Console.ReadLine();
                    eingabeOK = int.TryParse(benutzerEingabe, out kontonummer);

                    if (!eingabeOK)
                    {
                        Console.Write("Eingabe ungueltig");
                        System.Threading.Thread.Sleep(1000);
                    }
                }

                for (int i = 0; i < konten.Length; i++)
                {

                    if (int.Parse(benutzerEingabe) == konten[i].Kontonummer)
                    {
                        kontonummerBekannt = true;
                        kontoTemp = konten[i];
                        break;
                    }
                }
                

                if(!kontonummerBekannt)
                {
                    Console.Write("Kontonummer ist nicht bekannt");
                    System.Threading.Thread.Sleep(1000);
                }

            }

            
            while (!pinOK && !abbruch)
            {
                anzahlVersuche++;
                eingabeOK = false;
                while (!eingabeOK && !abbruch)
                {
                    Console.Clear();
                    Console.Write("Pin?: ");
                    benutzerEingabe = Console.ReadLine();
                    eingabeOK = int.TryParse(benutzerEingabe, out pin);

                    if (!eingabeOK)
                    {
                        Console.Write("Eingabe ungueltig");
                        System.Threading.Thread.Sleep(1000);
                    }

                }

                if (pin == kontoTemp.Pin)
                {
                    pinOK = true;
                }

                if(anzahlVersuche >= maxVersuche)
                {
                    Console.Write("Pin drei mal falsch eingegeben...");
                    abbruch = true;
                    System.Threading.Thread.Sleep(1000);

                }

            }

            Console.Clear();

            while (!MenuVerlassen)
            {
                eingabeOK = false;
                while (!eingabeOK && !abbruch)
                {
                    Console.Clear();
                    Console.WriteLine("Hallo {0}, was moechtest du tun?", kontoTemp.Vorname);
                    Console.WriteLine("(1) Kontostandabfragen\n(2) Geld abheben\n(3) Geld einzahlen\n(0) Abmelden");
                    Console.WriteLine("Deine Auswahl: ");
                    benutzerEingabe = Console.ReadLine();
                    eingabeOK = int.TryParse(benutzerEingabe, out menuAuswahl);
                }

                if (abbruch)
                {
                    menuAuswahl = 999;
                }
               
                switch (menuAuswahl)
                {
                    case 0:
                        Console.WriteLine("Auf Wiedersehen {0}", kontoTemp.Vorname);
                        MenuVerlassen = true;
                        break;

                    case 1:
                        Console.WriteLine("Kontostand abfragen");
                        kontoTemp.zeigeKontostand();
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case 2:
                        Console.WriteLine("Geld abheben");
                        Console.WriteLine("Wieviel moechtest du abheben?: ");
                        benutzerEingabe = Console.ReadLine();


                        while (!eingabeOK && !abbruch)
                        {
                            Console.Clear();
                            Console.Write("Pin?: ");
                            benutzerEingabe = Console.ReadLine();

                            eingabeOK = double.TryParse(benutzerEingabe, out betrag); // warum ist das 0

                            if (!eingabeOK)
                            {
                                Console.Write("Eingabe ungueltig");
                                System.Threading.Thread.Sleep(1000);
                            }

                        }

                        if (betrag <= kontoTemp.Kontostand)
                        {
                            Console.WriteLine("Betrag {0}:   Kontostand {1}", betrag, kontoTemp.Kontostand);
                            kontoTemp.abheben(betrag);
                        }
                        else
                        {
                            // TODO kommt nicht
                            Console.WriteLine("Soviel Geld hast du nicht du Trottel");
                        }

                        kontoTemp.zeigeKontostand();


                        System.Threading.Thread.Sleep(1000);
                        break;

                    case 3:
                        Console.WriteLine("Geld einzahlen");
                        Console.WriteLine("Wieviel moechtest du einzahlen?: ");
                        benutzerEingabe = Console.ReadLine();
                        kontoTemp.einzahlen(double.Parse(benutzerEingabe));
                        kontoTemp.zeigeKontostand();
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case 999:
                        Console.WriteLine("Hau ab du Asi !!!");
                        MenuVerlassen = true;
                        break;


                    default:
                        Console.WriteLine("Ungueltige Auswahl");
                        System.Threading.Thread.Sleep(1000);
                        break;

                }

            }

            Console.ReadKey();
        }
    }
}
