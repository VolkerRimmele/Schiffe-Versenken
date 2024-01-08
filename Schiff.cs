using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Schiffeversenken
{
    internal class Schiff
    {
        //static public void Eingabe(int anzahlSchiffe, int spielfeldLaenge, int spielfeldBreite, int spielfeldLaengeMax, int spielfeldLaengeMin, int spielfeldBreiteMax, int spielfeldBreiteMin)
        //{
            private int spielfeldLaenge;
            private int spielfeldBreite;
            private int schiffLaenge;
            private int schiffBreite;
            private int schiffLinksUntenLaenge;
            private int schiffLinksUntenBreite;

            public Schiff(int spielfeldLaenge, int spielfeldBreite, int schiffLaenge, int schiffBreite, int schiffLinksUntenLaenge, int schiffLinksUntenBreite)
            {
                SpielfeldLaenge = spielfeldLaenge;
                SpielfeldBreite = spielfeldBreite;
                SchiffLaenge = schiffLaenge;
                SchiffBreite = schiffBreite;
                SchiffLinksUntenLaenge = schiffLinksUntenLaenge;
                SchiffLinksUntenBreite = schiffLinksUntenBreite;
            }

            public int SpielfeldLaenge { get => spielfeldLaenge; set => spielfeldLaenge = value; }
            public int SpielfeldBreite { get => spielfeldBreite; set => spielfeldBreite = value; }
            public int SchiffLaenge { get => schiffLaenge; set => schiffLaenge = value; }
            public int SchiffBreite { get => schiffBreite; set => schiffBreite = value; }
            public int SchiffLinksUntenLaenge { get => schiffLinksUntenLaenge; set => schiffLinksUntenLaenge = value; }
            public int SchiffLinksUntenBreite { get => schiffLinksUntenBreite; set => schiffLinksUntenBreite = value; }


            static public void Eingabe(int anzahlSchiffe, int spielfeldLaenge, int spielfeldBreite, int spielfeldLaengeMax, int spielfeldLaengeMin, int spielfeldBreiteMax, int spielfeldBreiteMin)
            {
            Schiff[] Schiffe = new Schiff[15]; // Die Random erzeugten Schiffe werden später auch Index 11 d.h. aufE das 12te Feld gesetzt.

            int schiffLaenge;
            int schiffBreite;
            int schiffLinksUntenLaenge;
            int schiffLinksUntenBreite;

                 for (int i = 0; i < anzahlSchiffe; i++)
                {
                    //Schiffslänge    
                    Console.WriteLine($"Schiff {i + 1}:Bitte Länge des Schiffes eingeben - Werte von 1 - 10.");

                    schiffLaenge = Convert.ToInt32(Console.ReadLine());

                    while (schiffLaenge < 1 || schiffLaenge > 10)
                    {
                        Console.WriteLine($"Schiff {i + 1}: Eingabe war ungültig - Bitte Länge des Schiffes eingeben - Werte von 1 - 10.");
                        schiffLaenge = Convert.ToInt32(Console.ReadLine());
                    }
                    //Ende Schiffslänge

                    //Schiffsbreite
                    Console.WriteLine($"Schiff {i + 1}:Bitte Breite des Schiffes eingeben - Werte von 1 - 10.");
                    schiffBreite = Convert.ToInt32(Console.ReadLine());

                    while (schiffBreite < 1 || schiffBreite > 10)
                    {
                        Console.WriteLine($"Schiffe {i + 1}: Eingabe war ungültig - Bitte Breite des Schiffes eingeben - Werte von 1 - 10.");
                        schiffBreite = Convert.ToInt32(Console.ReadLine());
                    }
                    //Ende Schiffsbreite

                    //Position links unten Länge
                    Console.WriteLine($"Schiff {i + 1}: Bitte Position Links Unten Länge des Schiffes eingeben - Werte von 1 - {spielfeldLaengeMax}.");

                    schiffLinksUntenLaenge = Convert.ToInt32(Console.ReadLine());

                    while (schiffLinksUntenLaenge < 1 || schiffLinksUntenLaenge > spielfeldLaengeMax || schiffLinksUntenLaenge + schiffLaenge - 1 > spielfeldLaenge)
                    {
                        Console.WriteLine($"Schiffe {i + 1}: Eingabe war ungültig - Bitte Position Links Unter Länge des Schiffes eingeben - Werte von 1 - {spielfeldLaengeMax}. Schiff muss in Spielfeld passen");
                        schiffLinksUntenLaenge = Convert.ToInt32(Console.ReadLine());
                    }
                    //Ende Position links unter Länge


                    //Position links unten Breite
                    Console.WriteLine($"Schiff {i + 1}:Bitte Position Links Unten Breite des Schiffes eingeben - Werte von 1 - {spielfeldLaengeMax}.");
                    schiffLinksUntenBreite = Convert.ToInt32(Console.ReadLine());

                    while (schiffLinksUntenBreite < 1 || schiffLinksUntenBreite > spielfeldBreiteMax || schiffLinksUntenBreite + schiffBreite - 1 > spielfeldBreite)
                    {
                        Console.WriteLine($"Schiffe {i + 1}: Eingabe war ungültig - Bitte Position Links Unter Breite des Schiffes eingeben - Werte von 0 - {spielfeldBreiteMax}. Schiff muss in Spielfeld passen");
                        schiffLinksUntenBreite = Convert.ToInt32(Console.ReadLine());
                    }
                    //Ende Position links unten Breite

                    Schiffe[i] = new Schiff(spielfeldLaenge, spielfeldBreite, schiffLaenge, schiffBreite, schiffLinksUntenLaenge, schiffLinksUntenBreite);//Konstruktoraufruf
                }

                ////int startWert2 = 0;
                ////AusgabeBelegteFelder(startWert2);

                //Belegte Positionen = Spalten in einem Array Speichern - Ziel auf Doppelte überprüfen
                int[] belegteZahlen = new int[10000];

                //Belebte Position = Spalten in einem Array für die Random Schiffe
                int[] belegteZahlenRandom = new int[10000];

                //Zähler der mit Schiffen belegten Spalten bP alle Schiffe 1,2,3,4 für 1. 2. 3. 4. Schiff
                int zaehlerbP = 0;
                int zaehlerbP1 = 0;
                int zaehlerbP2 = 0;
                int zaehlerbP3 = 0;
                int zaehlerbP4 = 0;

                int startWert = 0;
                ArrayBelegteFelderErzeugen(startWert);//Methodenaufruf innerhalb der Eingabe Methode 

                //Belegte Spalten auf doppelte prüfen Array doppelte wird erzeugt
                int zaehlerDoppelte = 0;
                int[] doppelte = new int[10000];
                bool boolDoppelte = false;

                for (int d1 = 0; d1 < zaehlerbP - 1; d1++)
                {
                    boolDoppelte = false;
                    for (int d2 = d1 + 1; d2 < zaehlerbP; d2++)
                    {
                        if (belegteZahlen[d1] == belegteZahlen[d2])
                        {
                            doppelte[zaehlerDoppelte] = belegteZahlen[d1];
                            boolDoppelte = true;
                            //zaehlerDoppelte = zaehlerDoppelte + 1;
                        }
                        if (boolDoppelte == true)
                        {
                            zaehlerDoppelte = zaehlerDoppelte + 1;
                            break;
                        }
                    }
                }
                //Ende Belegte Spalten auf doppelte prüfen Array doppelte wird erzeugt


                if (zaehlerDoppelte > 0)
                {
                    Console.WriteLine($"\nDie Schiffe überschneiden sich - Bitte nochmal von vorne");
                    Console.WriteLine("Zum weiter machen - Bitte beliebige Taste Drücken");
                    Console.ReadKey();
                    Console.Clear();
                    //////User.Menue();
                }

                Console.WriteLine($"zaehlerDoppelte muss 0 sein: {zaehlerDoppelte}");
                Console.WriteLine($"Anzahl Schiffe: {anzahlSchiffe}");
                Console.WriteLine("Zum weiter machen - Bitte beliebige Taste Drücken");
                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 0);

                startWert = 0;
                Ausgabe(startWert);//Methodenaufruf zur Spielfeldausgabe incl der ERstellten Schiffe // Wird auch für die Random erzeugten Schiffe verwendet


                Console.SetCursorPosition(0, spielfeldBreite + 2);


                AusgabeDatenDerSchiffe(startWert);//Methodenaufruf zur Ausgabe der Daten der Schiffe. Wird auch für die Random erzeugten Schiffe verwendet

                startWert = 0;//Für die eingegebenen Schiffe 0, für die Random Schiffe später 11
                AusgabeBelegteFelder(startWert);//Methodenaufruf die mit Schiffen belegten Felder werden angelistet die Methode wird
                                                //mit den eingegebenen Schiffen und den Random Schiffen aufgerufen


                if (zaehlerDoppelte > 0)
                {

                    //Anzahl Doppelte sowie die doppelten Werte werden ausgelesen
                    Console.WriteLine($"\nAnzahl Doppelter: {zaehlerDoppelte}");

                    Console.WriteLine("Diese Zahlen sind doppelt: ");
                    for (int doppelt = 0; doppelt < zaehlerDoppelte; doppelt++)
                    {
                        Console.Write($"{doppelte[doppelt]},");
                    }
                    Console.WriteLine($"\nBitte nochmal von vorne/ Die Schiffe überschneiden sich");
                    User.Menue();//Funktionsaufruf - nochmal von Vorne wenn doppelte
                }

                ///ab HIER Neu /////////////////////////////////////////////////////////////////////////////////////        
                ///Computer erzeugt Random Schiffe

                if (zaehlerDoppelte == 0)//=keine Überschneidung bei den eingegebenen Schiffen
                {

                    bool boolDoppelteRandom = false;
                    do
                    {
                        //int[] belegteZahlenRandom = new int[10000];
                        int j = -1;
                        int zaehlerLaengeRandom = 0;

                        int zaehlerBpRandom = 0;//Zaehler belegte Positionen für Random


                        for (int i = 0; i < anzahlSchiffe; i++)
                        {


                            //Die vom Computer erzeugten Random-Schiffe werden erzeugt
                            //Spielfeld-Länge und Breite sowie die Größe der Schiffe sind mit den eingegebenen Schiffen identisch

                            spielfeldLaenge = Schiffe[i].SpielfeldLaenge;
                            spielfeldBreite = Schiffe[i].SpielfeldBreite;
                            schiffBreite = Schiffe[i].SchiffBreite;
                            schiffLaenge = Schiffe[i].SchiffLaenge;

                            int grenzWertLaenge = spielfeldLaenge - (schiffLaenge - 1);
                            int grenzWertBreite = spielfeldBreite - (schiffBreite - 1);


                            //Höchst Mögliche Zahl bei der das Schiff noch in das Koordinationsystem gesetzt werden kann // die niedrigst mögliche ist immer eins da links unten
                            //definiert

                            int hoechstMoeglicheZahl = (spielfeldLaenge * (spielfeldBreite - schiffBreite)) + grenzWertLaenge;

                            //Computer wählte einen Zufallswert zwischen 1 und der höchstmöglichen Zahl                                 
                            int randomZahl = 0;
                            bool bedingung = false;
                            do
                            {
                                Random rand1 = new Random();//Definition rand - Zur Erzeugung einer Zufallszahl
                                randomZahl = rand1.Next(1, hoechstMoeglicheZahl + 1);//Computer erzeugt ein Zahl zwischen 1 und und der Berechneten höchstmöglichen Zahl
                                if (((randomZahl % spielfeldLaenge) + schiffLaenge) > spielfeldLaenge + 1) //Schiff passt von der Länge nicht rein
                                {
                                    bedingung = false;
                                }
                                else if ((randomZahl % spielfeldLaenge == 0) && schiffLaenge > 1) //Schiff am Ende der Länge des Spielfeldes Module ist 0, Schiff darf max Länge 1
                                {
                                    bedingung = false;
                                }
                                else
                                {
                                    bedingung = true;//Schiff passt in Spielfeld, Schleife wird verlassen
                                }
                            } while (bedingung == false);

                            //Berechnung der Postionen der Schiffe mit Randomzahl und SpielfeldLaenge
                            if (randomZahl % spielfeldLaenge > 0)
                            {
                                schiffLinksUntenLaenge = (randomZahl % spielfeldLaenge);
                            }
                            else
                            {
                                schiffLinksUntenLaenge = spielfeldLaenge;
                            }

                            if (randomZahl % spielfeldLaenge > 0)
                            {
                                schiffLinksUntenBreite = (randomZahl / spielfeldLaenge) + 1;
                            }
                            else
                            {
                                schiffLinksUntenBreite = (randomZahl / spielfeldLaenge);
                            }

                            //Ende Berechnung der Position der Schiffe mit Randomzahl und Spielfeldlaenge

                            //belegte Zahlen bestimmen um sie dann auf doppelte zu prüfen
                            for (int zaehlerSchiffLaengeBreite = 0; zaehlerSchiffLaengeBreite < (schiffBreite * schiffLaenge); zaehlerSchiffLaengeBreite++)
                            {
                                j = j + 1;
                                if (zaehlerSchiffLaengeBreite < schiffLaenge)
                                {
                                    belegteZahlenRandom[j] = randomZahl + zaehlerSchiffLaengeBreite;
                                    zaehlerBpRandom = zaehlerBpRandom + 1;
                                }
                                else
                                {
                                    zaehlerLaengeRandom = zaehlerSchiffLaengeBreite / schiffLaenge;
                                    belegteZahlenRandom[j] = randomZahl + (zaehlerSchiffLaengeBreite - (zaehlerLaengeRandom * schiffLaenge)) + zaehlerLaengeRandom *
                                            spielfeldLaenge;
                                    zaehlerBpRandom = zaehlerBpRandom + 1;
                                }

                            }
                            //Ende belegte Zahlen bestimmen um sie dann auf doppelte zu überprüfen

                            Schiffe[i + 11] = new Schiff(spielfeldLaenge, spielfeldBreite, schiffLaenge, schiffBreite, schiffLinksUntenLaenge, schiffLinksUntenBreite);//Konstruktoraufruf für Random erzeugt Schiffe - Die Random Schiffe beginnnen bei Position 11


                        }  //Ende Große for-Schleife

                        //Überprüfung der belegten Randomwerte auf doppelte. Man bleibt so lange in der großen while Schleife bis es keine Doppelten mehr gibt
                        boolDoppelteRandom = false;
                        for (int d1 = 0; d1 < zaehlerBpRandom - 1; d1++)
                        {
                            //boolDoppelteRandom = false;
                            for (int d2 = d1 + 1; d2 < zaehlerBpRandom; d2++)
                            {
                                if (belegteZahlenRandom[d1] == belegteZahlenRandom[d2])
                                {
                                    boolDoppelteRandom = true;
                                    break;
                                }
                            }
                        } //Ende for-Schleife
                          //Ende Überprüfung der belegten Randomwerte auf doppelte. Man bleibt so lange in der großen while Schleife bis es keine Doppelten mehr gibt.

                    } while (boolDoppelteRandom == true);


                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Zum weiter machen - Bitte beliebige Taste Drücken");
                    Console.ReadKey();

                    startWert = 11;

                    Console.WriteLine("Wollen Sie die Daten der Random erzeugten Schiffe zum TESTEN sehen (J)a oder (N)ein?");
                    string randomSehen = Console.ReadLine().ToLower();//Macht aus Großbuchstaben Kleinbuchstaben


                    string[] randomSehenString = {"j", "ja", "n", "nein" };//Nur Kleinbuchstaben wegen ToLower()
                    bool randomSehenBool = true;

                    while (randomSehenBool == true)
                    {
                        foreach (string einzelrandomSehen in randomSehenString)//Jede vorgegebene Antwortmöglichkeit in dem String-Array randomSehenString wird durchlaufen
                        {
                            if (einzelrandomSehen == randomSehen)//Prüfung ob die jeweilige Anwortmöglichkeit (einzelrandomSehen) des String-Arrays mit dem vom user eingebenen randomSehen übereinstimmt
                            {
                                 randomSehenBool = false;//Wenn false war die Eingabe richtig, und die while Schleife wird verlassen. Der zuerst eingelesene Wert bleibt
                            }

                        }
                        if (randomSehenBool == true) Console.WriteLine($"Bitte Angeben ob Sie Random Schiffe sehen wollen = (J)a oder  = (N)ein.");
                        if (randomSehenBool == true) randomSehen = Console.ReadLine().ToLower();
                    }

                    if (randomSehenBool == false && (randomSehen == "j" || randomSehen == "ja"))
                    {
                        AusgabeDatenDerSchiffe(startWert);//Methodenaufruf. Daten der Random erzeugten Schiffe werden ausgegeben.
                                                          //Methode wird auch verwendet um Daten der eingegeben Schiffe auszugeben
                    }                                  


                    //Anzeige Spielfeld und Schiffe
                    Console.WriteLine("Zum weiter machen - Bitte beliebige Taste Drücken");
                    Console.ReadKey();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);


                    //Ausgabe mit Eingegebenen und Random Schiffen // Bei Random wird Startwert 11 übergeben bei den eingegebenen Schiffen der Startwert 0.

                    //Ausgabe(startWert);// Methodenaufruf zum Anschauen der Schiffe der Startwert 11 wird übergeben, der Startindex auf den die Random Schiffe gesetzt werden.
                    //ArrayBelegteFelderErzeugen(startWert); //Methodenaufruf um die belegten Felder zu erzeugen

                    Console.WriteLine("Wollen Sie die Daten der Random erzeugten Schiffe zum TESTEN sehen (J)a oder (N)ein?");
                    string randomSehen2 = Console.ReadLine().ToLower();//Macht aus Großbuchstaben Kleinbuchstaben


                    string[] randomSehenString2 = { "j", "ja", "n", "nein" };//Nur Kleinbuchstaben wegen ToLower()
                    bool randomSehenBool2 = true;

                    while (randomSehenBool2 == true)
                    {
                        foreach (string einzelrandomSehen2 in randomSehenString2)//Jede vorgegebene Antwortmöglichkeit in dem String-Array randomSehenString wird durchlaufen
                        {
                            if (einzelrandomSehen2 == randomSehen2)//Prüfung ob die jeweilige Anwortmöglichkeit (einzelrandomSehen) des String-Arrays mit dem vom user eingebenen randomSehen übereinstimmt
                            {
                                randomSehenBool2 = false;//Wenn false war die Eingabe richtig, und die while Schleife wird verlassen. Der zuerst eingelesene Wert bleibt
                            }

                        }
                        if (randomSehenBool2 == true) Console.WriteLine($"Wollen Sie die Random Schiffe Graphisch sehen wollen = (J)a oder  = (N)ein.");
                        if (randomSehenBool2 == true) randomSehen2 = Console.ReadLine().ToLower();
                    }

                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                    if (randomSehenBool2 == false && (randomSehen2 == "j" || randomSehen2 == "ja"))
                    {
                        Ausgabe(startWert);//Methodenaufruf. Daten der Random erzeugten Schiffe werden ausgegeben.
                        //AusgabeBelegteFelder(startWert); //Ausgabe der belegten Felder                                  
                    }

                    ArrayBelegteFelderErzeugen(startWert); //Methodenaufruf um die belegten Felder zu erzeugen

                    if (randomSehenBool2 == false && (randomSehen2 == "j" || randomSehen2 == "ja"))
                    {
                        //Ausgabe(startWert);//Methodenaufruf. Daten der Random erzeugten Schiffe werden ausgegeben.
                        AusgabeBelegteFelder(startWert); //Ausgabe der belegten Felder                                  
                    }



                }//Ende if Doppelte = 0  // die Random Schiffe werden erst unter der Bedingung erstellt, dass es bei den eingegeben Schiffen keine doppelten mehr gibt.
                 //Ende Computer erzeugt Random Schiffe

                //}//Ende Funktion Eingabe

                    //Die Methode zum Ausgeben der Daten der Schiffe wird sowohl für die eingegebenden Schiffe als auch für die Random Schiffe aufgerufen, einziger Unterschied ist der Startwert
                    //bei den Eingebenen Schiffen ist er Null = Index 0 bei den Random Schiffen 11 (=Index 11)
                    void AusgabeDatenDerSchiffe(int startWert)
                    {
                        for (int i = 0 + startWert; i < anzahlSchiffe + startWert; i++)
                        {
                            if (startWert == 0) Console.WriteLine($"Schiffe {i + 1}: Spielfeldlänge: {Schiffe[i].SpielfeldLaenge}, Spielfeldbreite: {Schiffe[i].SpielfeldBreite}, Länge: {Schiffe[i].SchiffLaenge}, Breite: {Schiffe[i].SchiffBreite}, Position Länge links unten: {Schiffe[i].SchiffLinksUntenLaenge}, Position Breite links unten: {Schiffe[i].SchiffLinksUntenBreite}");

                            if (startWert > 0) Console.WriteLine($"SchiffeRandom {i}: Spielfeldlänge: {Schiffe[i].SpielfeldLaenge}, Spielfeldbreite: {Schiffe[i].SpielfeldBreite}, Länge: {Schiffe[i].SchiffLaenge}, Breite: {Schiffe[i].SchiffBreite}, Position Länge links unten: {Schiffe[i].SchiffLinksUntenLaenge}, Position Breite links unten: {Schiffe[i].SchiffLinksUntenBreite}");

                        }
                    }


                    //Die Methode zum Ausschauen der Schiffe wird sowohl für die eingegebenden Schiffe als auch für die Random Schiffe aufgerufen, einziger Unterschied ist der Startwert
                    //bei den Eingebenen Schiffen ist er Null = Index 0 bei den Random Schiffen 11 (=Index 11)
                    void Ausgabe (int startWert)//Methode innerhalb der Eingabemethode
                    {

                        for (int b = spielfeldBreite; b >= 0; b--)
                        {
                            Console.SetCursorPosition((0), (spielfeldBreite - b));
                            if (b >= 10 || b == 0) Console.WriteLine($"{b} ");
                            if (b < 10 && b > 0) Console.WriteLine($"0{b} ");

                            for (int k = startWert; k < startWert + anzahlSchiffe; k++)
                            {
                                for (int l = 0; l <= spielfeldLaenge; l++)
                                {
                                    if ((b <= ((Schiffe[k].SchiffLinksUntenBreite + Schiffe[k].SchiffBreite - 1)) && b >= Schiffe[k].SchiffLinksUntenBreite) && (l <= ((Schiffe[k].SchiffLinksUntenLaenge + Schiffe[k].SchiffLaenge - 1)) && l >= Schiffe[k].SchiffLinksUntenLaenge))
                                    {
                                        Console.SetCursorPosition(((l * 3)), (spielfeldBreite - b));
                                        Console.Write("S");
                                    }
                                }
                                if (b > 0)
                                {
                                    Console.SetCursorPosition(0, spielfeldBreite - b);
                                    Console.Write("\n");
                                }
                            }
                        }
                        for (int l = 1; l <= spielfeldLaenge; l++)
                        {
                            Console.SetCursorPosition((l * 3), spielfeldBreite);
                            if (l >= 10) Console.WriteLine($"{l}");
                            if (l < 10) Console.WriteLine($"0{l}");
                        }
                    }//Ende Methode Ausgabe zum Auschauen der Schiffe sowohl eingegebene als auch Random Schiffe


                    //Belegte Positionen = Spalten in einem Array Speichern für Eigene Schiffe und für Random Schiffe - an dieser Stelle darf es keine doppelten mehr geben
                    void ArrayBelegteFelderErzeugen(int startWert)//Methode innerhalb der Eingabemethode
                    {
                        zaehlerbP = 0; //Zähler ist für Eingegeben Schiffe und für Random Schiffe identische, da die gleichen Schiffe verwendet und nur anders positioniert werden

                        for (int a = 0 + startWert; a < anzahlSchiffe + startWert; a++)
                        {
                            for (int sB = 1; sB <= Schiffe[a].SchiffBreite; sB++)
                            {
                                for (int bP = (Schiffe[a].SpielfeldLaenge) * (Schiffe[a].SchiffLinksUntenBreite - 1) + (Schiffe[a].SchiffLinksUntenLaenge) + ((sB - 1) * Schiffe[a].SpielfeldLaenge); bP <= (Schiffe[a].SpielfeldLaenge) * (Schiffe[a].SchiffLinksUntenBreite - 1) + (Schiffe[a].SchiffLinksUntenLaenge) + (Schiffe[a].SchiffLaenge - 1) + ((sB - 1) * Schiffe[a].SpielfeldLaenge); bP++)
                                {
                                    if (startWert == 0) belegteZahlen[zaehlerbP] = bP;
                                    if (startWert > 0) belegteZahlenRandom[zaehlerbP] = bP;
                                    zaehlerbP = zaehlerbP + 1;
                                }
                            }
                        if (startWert == 0 && a == 0) zaehlerbP1 = zaehlerbP; // gibt an bei welchem Zählerstand das 1. te Schiff zu ende ist.
                        if (startWert == 0 && a == 1) zaehlerbP2 = zaehlerbP; // gibt an bei welchem Zählerstand das 2. te Schiff zu ende ist.
                        if (startWert == 0 && a == 2) zaehlerbP3 = zaehlerbP; // gibt an bei welchem Zählerstand das 3. te Schiff zu ende ist.
                        if (startWert == 0 && a == 3) zaehlerbP4 = zaehlerbP; // gibt an bei welchem Zählerstand das 4. te Schiff zu ende ist.
                        }
                    }
                    //Ende Belegte Positionen in einem Array speichern für Eigene Schiffe und für Random Schiffe

                    //Mit Schiffen belegte Postionen ausgeben für eingegebene Schiffe und für Random erzeugte Schiffe
                    void AusgabeBelegteFelder(int startWert)
                    {
                        Console.WriteLine($"\nBelegte Zahlen:");
                        for (int bPList = 0; bPList < zaehlerbP; bPList++)
                        {
                            ////Console.Write($"Belegte Spalten: {belegteZahlen[zaehlerbP]}");
                            if (startWert == 0) Console.Write($"{belegteZahlen[bPList]},");
                            if (startWert > 0) Console.Write($"{belegteZahlenRandom[bPList]},");
                            //////Thread.Sleep(2500);
                        }
                    }
                //Ende Die mit Schiffen belegten Positionen ausgeben für eingegebene Schiffe und für Random erzeugte Schiffe.

                int eingabeZahl;//Die vom User eingegebene Zahl
                bool check2;

                do
                {
                    Console.WriteLine("Was möchten Sie Tun, 1=nur gegen Computer Spielen, 2 = Computer spielt nur gegen dich, 3=Abwechselndes Spiel, 4=Abbruch ");
                    check2 = int.TryParse(Console.ReadLine(), out eingabeZahl);//Check wird true wenn Konvertierung zu int erfolgreich

                    switch (eingabeZahl)
                    {
                        case 1:
                            //Aufruf zum eigentlichen Spiel Wir Spielen Nur gegen den Computer
                            Spiel.AufrufSpielNurGegenComputer(spielfeldLaenge, spielfeldBreite, zaehlerbP, belegteZahlenRandom);
                            //Menuefuehrung.Menuefuehrung2();
                            break;
                        case 2:
                            SpielComputer.AufrufComputerNurGegenDich(spielfeldLaenge, spielfeldBreite, zaehlerbP, zaehlerbP1, zaehlerbP2, zaehlerbP3, zaehlerbP4, belegteZahlen);
                            break;
                       case 3:
                            //Aufruf zum Abwechselden Spiel
                            SpielAbwechselnd.AufrufSpielAbwechselnd(spielfeldLaenge, spielfeldBreite, zaehlerbP, zaehlerbP1, zaehlerbP2, zaehlerbP3, zaehlerbP4, belegteZahlen, belegteZahlenRandom);
                            //Menuefuehrung.Menuefuehrung2();
                            break;
                       default:
                            Console.WriteLine("Ungültige Eingabe. Bitte 1-3 eingeben, 1=nur gegen Computer Spielen, 2 = Computer spielt nur gegen dich, 3=Abwechselndes Spiel");
                            break;
                    }


                } while (check2 == false || eingabeZahl < 1 || eingabeZahl > 3);//Schleife wird nur verlassen wenn Zahl größer 3 eingegeben wird
            
            
        }//Ende Methode Eingabe    
        //Spiel.AufrufSpielNurGegenComputer(SpielfeldLaenge, SpielfeldBreite, zaehlerbP, belegteZahlen, belegteZahlenRandom);

    }//Ende Klasse Schiff
}//Ende Namespcade


































