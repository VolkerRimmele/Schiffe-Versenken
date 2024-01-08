using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenken
{
    internal class Spiel
    {
        public static void AufrufSpielNurGegenComputer(int spielfeldLaenge, int spielfeldBreite, int zaehlerbP, int[] belegteZahlenRandom)
        {
            bool check;//Zur Überprüfung ob die Eingaben gültig sind - Try.Parse gibt true zurück wenn Umwandlung von sting in int erfolgreich
            bool doppeltGetippt = false;//Wird verwendet zum Prüfen auf doppelte Eingaben des Spielers
            int x;//Vom Spieler eingegebene Koordinate x-Achse = Länge
            int y;//Vom Spieler eingegebene Koordinate Y-Achse = Breit (Höhe)

            int zaehlerTrefferRandom = 0;//Zählt die Treffer des Spieler bei den Random Schiffen
            int anzahlVersuche = 0;//Die Anzahl der Eingaben werden gezählt. Die doppelten Eingaben werden herausgerechnet.

            int[] koordinaten = new int[10000];//die eingetippten Felder werden als ARRAY gespeicht um dann auch doppelte Eingaben zu prüfen

            Console.WriteLine("Das Spiel Beginnt Zum weiter machen - Bitte beliebige Taste Drücken");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.WriteLine($"Bitte Längen-Koordinate eingeben (x = 1 bis {spielfeldLaenge}).");
                do
                {
                    check = (int.TryParse(Console.ReadLine(), out x) && (x >= 1 && x <= spielfeldLaenge));
                    if (check == false)
                    {
                        Console.WriteLine($"Eingabe war ungültig - Bitte LängenKoordinaten X eingeben - Werte von 1 - {spielfeldLaenge}.");
                    }
                } while (check == false);

                Console.WriteLine($"Bitte Breiten-Koordinate eingeben (y = 1 bis {spielfeldBreite}).");
                do
                {
                    check = (int.TryParse(Console.ReadLine(), out y) && (y >= 1 && y <= spielfeldBreite));
                    if (check == false)
                    {
                        Console.WriteLine($"Eingabe war ungültig - Bitte BreitenKoordinaten Y eingeben - Werte von 1 - {spielfeldBreite}.");
                    }
                } while (check == false);


                WurdeGetroffen(x, y);//Methodenaufruf - Methode prüft ob die eingegebenen Koordinaten ein Treffer sind
            } while (zaehlerTrefferRandom < zaehlerbP);
            //// 
        
        

            void WurdeGetroffen(int x, int y)//Eingegebene Koordinaten werden übergeben
            {
                doppeltGetippt = false;//Wenn die Zahl schonmal eingegeben wurde wird der bool auf true gesetzt. Die Anzahl Versuche werden dann zurückgesetzt
                                       //und die Zahl wird NICHT als Treffer gewertet
                anzahlVersuche++;
                int koordinate = ((y - 1) * spielfeldLaenge) + x;//Umrechnung von x,y in das eindimensionale Zahlensystem des Random Arrays
                koordinaten[anzahlVersuche - 1] = koordinate;//Der int-Array Koordinaten wird gefüllt um jeden neuen Wert mit den alten Werten vergleichen zu können 

                if (anzahlVersuche > 1)
                {
                    for (int i = 0; i < anzahlVersuche - 1; i++)
                    {
                        if (koordinaten[i] == koordinate)//alle bisherigen Werte werden mit dem aktuellen Wert verglichen
                        {
                            doppeltGetippt = true;//Bei True werden die Treffer nicht gezählt und die Anzahl Versuche um 1 zurückgesetzt
                            break;
                        }
                    }
                }
                for (int i = 0; i < zaehlerbP; i++)
                {
                    if ((koordinate == belegteZahlenRandom[i]) && doppeltGetippt == false) zaehlerTrefferRandom++;
                }
                if (doppeltGetippt == true) anzahlVersuche = anzahlVersuche - 1;//Anzahl Versuche werden zurückgesetzt
                if (doppeltGetippt == true) Console.WriteLine("Die Koordinaten wurden schon einmal eingeben, NICHT als Versuch und NICHT als Treffer gewertet");
                Console.WriteLine($"Das war der {zaehlerTrefferRandom}. Treffer. von {anzahlVersuche} Versuchen");

            }//Ende Methode WurdeGetroffen
       }//Ende Methode Aufruff
    }//Ende Klasse
}//Ende Namespace
