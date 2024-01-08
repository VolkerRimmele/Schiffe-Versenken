using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenken
{
    internal class User
    {
        public static void Menue()
        {
            int anzahlSchiffe = 0;
            int spielfeldLaenge;
            int spielfeldBreite;
            bool check;
            bool eingabeBool = true;

            const int spielfeldLaengeMin = 10;
            const int spielfeldLaengeMax = 50;
            const int spielfeldBreiteMin = 10;
            const int spielfeldBreiteMax = 50;
            //Eingabe Anzahl Schiffe nur Einmal
                     

            do
            {
                Console.WriteLine("Zum weiter machen - Bitte beliebige Taste Drücken");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Wir spielen Schiffe versenken, mit wie vielen Schiffen wollen Sie Spielen (1-4) möglich");
                string eingabeString = Console.ReadLine();

                if (eingabeString == "1" || eingabeString == "2" || eingabeString == "3" || eingabeString == "4")
                {
                    Console.Clear();
                    anzahlSchiffe = Convert.ToInt32(eingabeString);
                    eingabeBool = false;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte 1 oder 2 oder 3 oder 4 eingeben");
                }
            } while (eingabeBool == true);
            //Eingabe Anzahl Schiffe nur 1 mal


            //Eingabe SpielfeldLänge
            Console.WriteLine($"Bitte Die Spielfeldlänge eingeben - Werte von {spielfeldLaengeMin} - {spielfeldLaengeMax}.");
            do
            {
                check = (int.TryParse(Console.ReadLine(), out spielfeldLaenge) && (spielfeldLaenge >= spielfeldLaengeMin && spielfeldLaenge <= spielfeldLaengeMax));
                if (check == false)
                {
                    Console.WriteLine($"Eingabe war ungültig - Bitte Spielfeldlänge eingeben - Werte von {spielfeldLaengeMin} - {spielfeldLaengeMax}.");
                }
            } while (check == false);
            //Ende Eingabe Spielfeldlänge

            //Eingabe SpielfeldBreite
            Console.WriteLine($"Bitte Die Spielfeldbreite eingeben - Werte von {spielfeldBreiteMin} - {spielfeldBreiteMax}.");
            do
            {
                check = (int.TryParse(Console.ReadLine(), out spielfeldBreite) && (spielfeldBreite >= spielfeldBreiteMin && spielfeldBreite <= spielfeldBreiteMax));
                if (check == false)
                {
                    Console.WriteLine($"Eingabe war ungültig - Bitte Spielfeldbreite eingeben - Werte von {spielfeldBreiteMin} - {spielfeldBreiteMax}.");
                }
            } while (check == false);
            //Ende Eingabe SpielfeldBreite


            Schiff.Eingabe(anzahlSchiffe, spielfeldLaenge, spielfeldBreite, spielfeldLaengeMax,spielfeldLaengeMin,spielfeldBreiteMax,spielfeldBreiteMin);//Methodenaufruf
        }
   
    }//Ende Class user

}
