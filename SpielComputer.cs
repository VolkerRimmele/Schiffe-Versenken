namespace Schiffeversenken
{
    internal class SpielComputer
    //Der Computer spielt gegen uns
    {

        public static void AufrufComputerNurGegenDich(int spielfeldLaenge, int spielfeldBreite, int zaehlerbP,int zaehlerbP1, int zaehlerbP2, int zaehlerbP3, int zaehlerbP4, int[] belegteZahlen)
        {
      
            
            //Computer spielt gegen Spieler
            bool doppeltGetippt = false;//Wird zum Prüfen auf doppelte Erzeugte Random Zahlen verwendet
            int zaehlerTreffer = 0;//Zählt die Treffer des Computer bei den vom Spieler eingegebenen Schiffen
            int anzahlVersuche = 0;//Die Anzahl der Eingaben des Computers werden gezählt. Die doppelten Eingaben werden herausgerechnet.
            int[] koordinaten = new int[10000];//die eingetippten Felder werden als ARRAY gespeicht um dann auch doppelte Eingaben zu prüfen
            bool treffer = false;//gibt ob Treffer oder kein Treffer

            int xRandom = 0;//Vom Computer erzeugte Koordinate x-Achse = Länge
            int yRandom = 0;//Vom Computer eingegebene Koordinate Y-Achse = Breit (Höhe)
            int randomZahl = 0;
            int indexBelegterTreffer = 10000;//Initialisiert mit einem Wert der nicht vorkommen kann weil 50*50 = 2500 (max länge * max Breite)
            int indexBelegterTrefferVorher = 10000;//Initialisiert mit einem Wert der nicht vorkommen kann weil 50*50 = 2500 (max länge * max Breite)

            int[] zaehlerTrefferNichtTreffer = new int[1000];//die Felder werden mit 1 Treffer oder 0 NICHT Treffer gefüllt weil ich den Fall kein Treffer und vorher Treffer separate behandeln will
            int zaehlerErzeugteZahlen = 0;
            int richtung = -1;//nach rechts oder links
            int startWert = 0; //Der erste belegte RandomWert um neu aufzusetzen wenn es kein 2 mal keinen Treffer gibt. Wird für alle 4 Schiffe einzeln bestimmt
            bool neuBeginn = false;//Zum Neuaufsetzen damit das Schiff komplett abgearbeitet werden kann. Vorher wir Schiff nach recht und nach unten abgearbeitet
                                   //nach dem Aufsetzen bei Neubeginn nach links und nach oben 
            bool flagge = false;
            
            //Für das berechnen ob einzelne Schiffe abgeräumt sind
            bool flaggeBelegt1 = false;//damit das Abräumen der Schiffe nur einmal berechnet wird
            bool flaggeBelegt2 = false;//damit das Abräumen der Schiffe nur einmal berechnet wird
            bool flaggeBelegt3 = false;//damit das Abräumen der Schiffe nur einmal berechnet wird
            bool flaggeBelegt4 = false;//damit das Abräumen der Schiffe nur einmal berechnet wird

            bool abgeraeumt1 = false;//gibt an die die Schiffe vollständig abgeräumt sind sind 1.tes
            bool abgeraeumt2 = false;//gibt an die die Schiffe vollständig abgeräumt sind sind 2.tes
            bool abgeraeumt3 = false;//gibt an die die Schiffe vollständig abgeräumt sind sind 3.tes
            bool abgeraeumt4 = false;//gibt an die die Schiffe vollständig abgeräumt sind sind 4.tes

            int bPzaehler1 = 0;//Zähler dür die belegten Position der einzelnen Schiff zu Berechnen von Abgeräumt 1
            int bPzaehler2 = 0;//Zähler dür die belegten Position der einzelnen Schiff zu Berechnen von Abgeräumt 2
            int bPzaehler3 = 0;//Zähler dür die belegten Position der einzelnen Schiff zu Berechnen von Abgeräumt 3
            int bPzaehler4 = 0;//Zähler dür die belegten Position der einzelnen Schiff zu Berechnen von Abgeräumt 4
            //Ende für das Berechnen ob einzelne SChiffe abgeräumt sind
            //Ende Computer spielt gegen Spieler


            Console.WriteLine("Das Spiel Beginnt Zum weiter machen - Bitte beliebige Taste Drücken");
            Console.ReadKey();
            Console.Clear();
            ComputerErzeugtRandomZahl();//Die Random Schiffe werden erzeugt

            void ComputerErzeugtRandomZahl()
            {
                do
                {
                    do
                    {


                        if (treffer == false)//Wenn die vorherige Random Zahl KEIN Treffer war wird die Zahl einfach per Zufall auswählen über das Gesamte Spielfeld ausgewählt
                        {
                            randomZahl = 0;
                            Random rand1 = new Random();//Definition rand - Zur Erzeugung einer Zufallszahl
                            randomZahl = rand1.Next(1, spielfeldLaenge * spielfeldBreite + 1); //Computer erzeugt ein Zahl zwischen 1 und und der Berechneten höchstmöglichen Zahl
                        }
                        if (treffer == true)
                        {
                            //1. ter Treffer beim 1.ten Schiff merken zum neu Aufsetzen
                            if (zaehlerTreffer == 1) startWert = belegteZahlen[indexBelegterTreffer];

                            
                            if (abgeraeumt1 == true && flaggeBelegt1 == false)//Wenn der Startwert für ein Schiff berechnet wurde muss er nicht nachmal
                            //berechnet werden, deshalb wir die Flaggebelegt dann auf true gesetzt
                            {
                                startWert = belegteZahlen[indexBelegterTreffer];
                                flaggeBelegt1 = true;
                                neuBeginn = false;
                                
                            }
                            if (abgeraeumt2 == true && flaggeBelegt2 == false)
                            {
                                startWert = belegteZahlen[indexBelegterTreffer];
                                flaggeBelegt2 = true;
                                neuBeginn = false;
                                
                            }
                            if (abgeraeumt3 = true && flaggeBelegt3 == false)
                            {
                                startWert = belegteZahlen[indexBelegterTreffer];
                                flaggeBelegt3 = true;
                                neuBeginn = false;
                                
                            }
                            if (abgeraeumt4 = true && flaggeBelegt4 == false)
                            {
                                startWert = belegteZahlen[indexBelegterTreffer];
                                flaggeBelegt4 = true;
                                neuBeginn = false;
                            }


                            if (indexBelegterTreffer + 1 <= zaehlerbP1 && flaggeBelegt1 == false)//die zahlerbP1...bP4 sind fortlaufend deshalb mussen für die einzelnen
                            //Schiffe die Differenzen dieser Werte betrachtet werden bP1..bP4 sind die Zählerstände bei denn die Schiffe Zuende sind
                            //als bP1 ist z.B bei 4 zuEnde und bP2 bei 20. Dann mussen sozusagen von 5-20 gezählt werden für das 2te. Schiff 
                            {
                                bPzaehler1 = bPzaehler1 + 1;
                                if (bPzaehler1 == zaehlerbP1) abgeraeumt1 = true;
                                if (bPzaehler1 == zaehlerbP1) neuBeginn = false;
                            }

                            if (indexBelegterTreffer + 1 > zaehlerbP1 && indexBelegterTreffer + 1 <= zaehlerbP2 && flaggeBelegt2 == false)
                            {
                                bPzaehler2 = bPzaehler2 + 1;
                                if (bPzaehler2 == zaehlerbP2 - zaehlerbP1) abgeraeumt2 = true;
                                if (bPzaehler2 == zaehlerbP2 - zaehlerbP1) neuBeginn = false;
                            }

                            if (indexBelegterTreffer + 1 > zaehlerbP2 && indexBelegterTreffer + 1 <= zaehlerbP3 && flaggeBelegt3 == false)
                            {
                                bPzaehler3 = bPzaehler3 + 1;
                                if (bPzaehler3 == zaehlerbP3 - zaehlerbP2) abgeraeumt3 = true;
                                if (bPzaehler3 == zaehlerbP3 - zaehlerbP2) neuBeginn = false;
                            }

                            if (indexBelegterTreffer + 1 > zaehlerbP3 && indexBelegterTreffer + 1 <= zaehlerbP4 && flaggeBelegt4 == false)
                            {
                                bPzaehler4 = bPzaehler4 + 1;
                                if (bPzaehler4 == zaehlerbP4 - zaehlerbP3) abgeraeumt4 = true;
                                if (bPzaehler4 == zaehlerbP4 - zaehlerbP3) neuBeginn = false;
                            }


                            //Startwerte zum neuaufsetzen für die Schiffe definiren
                            if (belegteZahlen[indexBelegterTreffer] % spielfeldLaenge == 0) randomZahl = belegteZahlen[indexBelegterTreffer] - 1;//Am Ende des Spielfelds nach links
                            if (belegteZahlen[indexBelegterTreffer] % spielfeldLaenge > 0) randomZahl = belegteZahlen[indexBelegterTreffer] + 1;//Sonst nach rechts

                            //Wenn es jetzt und vorher einen Treffer gibt bzw. gab gehen wir in der gleichen Richtung weiter in der Länge mit +1 nach rechts -1 nach links 
                            if (indexBelegterTrefferVorher != 10000 && belegteZahlen[indexBelegterTreffer] > 1 && belegteZahlen[indexBelegterTreffer] < spielfeldBreite * spielfeldLaenge)
                            {
                                if (belegteZahlen[indexBelegterTrefferVorher] + 1 == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] + 1;
                                if (belegteZahlen[indexBelegterTrefferVorher] - 1 == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] - 1;
                            }

                            //Wenn es jetzt und vorher einen Treffer gibt bzw. gab die den Abstand einer Spielfeldlänge hatten gehen wir abwechseln nach links oder rechts weiter bis es keinen Treffer
                            //mehr gibt - danach gehts dann wieder eine Spielfeldlänge nach unter (wenn kein Treffer und vorher Treffer)
                            if (indexBelegterTrefferVorher != 10000 && belegteZahlen[indexBelegterTreffer] > 1 && belegteZahlen[indexBelegterTreffer] < (spielfeldBreite * spielfeldLaenge) - spielfeldLaenge)
                            {

                                if (belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] + richtung;
                                if (belegteZahlen[indexBelegterTrefferVorher] - spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] + richtung;


                                //Nach dem neu Aufsetzen erstmal nach rechts egal was vorher war
                                if ((belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) && neuBeginn == true && (belegteZahlen[indexBelegterTrefferVorher] - startWert < 0)) richtung = 1;
                                if ((belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) && neuBeginn == true && (belegteZahlen[indexBelegterTrefferVorher] - startWert < 0)) randomZahl = belegteZahlen[indexBelegterTreffer] + richtung;

                                if ((belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) && neuBeginn == true && (startWert - belegteZahlen[indexBelegterTrefferVorher] == 0)) richtung = 1;
                                if ((belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) && neuBeginn == true && (startWert - belegteZahlen[indexBelegterTrefferVorher] == 0)) randomZahl = belegteZahlen[indexBelegterTreffer] + richtung;
                                //Ende Nach dem neu Aufsetzen erst mal nach recht egal was vorher war

                                if (belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) richtung = richtung * (-1); // Bei jedem Durchlauf wird die Richtung gewechselt.
                                if (belegteZahlen[indexBelegterTrefferVorher] - spielfeldLaenge == belegteZahlen[indexBelegterTreffer]) richtung = richtung * (-1); // Bei jedem Durchlauf wird die Richtung gewechselt.
                            }
                        }//Ende if Treffer = true

                        if (treffer == true) zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen] = 1;
                        if (treffer == false && doppeltGetippt == false) zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen] = 0;

                        //Jetzt kein Treffer, aber vorher Treffer
                        if (zaehlerErzeugteZahlen >= 1 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 1] == 1)//Jetzt kein Treffer aber vorher Treffer
                        {

                            if (indexBelegterTrefferVorher != 10000 && indexBelegterTrefferVorher >= 1)
                            {
                                if (neuBeginn == false)
                                //if (neuBeginn == false && (koordinaten[anzahlVersuche - 1] - 1 == belegteZahlen[indexBelegterTrefferVorher] || koordinaten[anzahlVersuche - 1] + 1 == belegteZahlen[indexBelegterTrefferVorher]))
                                {
                                    if (belegteZahlen[indexBelegterTrefferVorher] > spielfeldLaenge && belegteZahlen[indexBelegterTrefferVorher] < spielfeldLaenge * spielfeldBreite - spielfeldLaenge)
                                    {
                                        randomZahl = belegteZahlen[indexBelegterTrefferVorher] - spielfeldLaenge;

                                    }
                                    if (belegteZahlen[indexBelegterTrefferVorher] <= spielfeldLaenge) randomZahl = belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge;
                                    if (belegteZahlen[indexBelegterTrefferVorher] >= spielfeldLaenge * spielfeldBreite - spielfeldLaenge) randomZahl = belegteZahlen[indexBelegterTrefferVorher] - spielfeldLaenge;
                                }
                            }
                            if (indexBelegterTrefferVorher != 10000 && indexBelegterTrefferVorher >= 1)
                            {
                                if (neuBeginn == true)
                                //if (neuBeginn == true && (koordinaten[anzahlVersuche - 1] - 1 == belegteZahlen[indexBelegterTrefferVorher] || koordinaten[anzahlVersuche - 1] + 1 == belegteZahlen[indexBelegterTrefferVorher]))
                                {
                                    if (belegteZahlen[indexBelegterTrefferVorher] > spielfeldLaenge && belegteZahlen[indexBelegterTrefferVorher] < spielfeldLaenge * spielfeldBreite - spielfeldLaenge)
                                    {
                                        randomZahl = belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge;
                                    }
                                    if (belegteZahlen[indexBelegterTrefferVorher] <= spielfeldLaenge) randomZahl = belegteZahlen[indexBelegterTrefferVorher] + spielfeldLaenge;
                                    if (belegteZahlen[indexBelegterTrefferVorher] >= spielfeldLaenge * spielfeldBreite - spielfeldLaenge) randomZahl = belegteZahlen[indexBelegterTrefferVorher] - spielfeldLaenge;
                                }
                            }

                        }//Ende Jetzt kein Treffer und vorher Treffer

                        //2 mal kein Treffer und Vorher Treffer
                        if (neuBeginn == false && zaehlerErzeugteZahlen >= 2 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 1] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 2] == 1)
                        {
                            randomZahl = startWert - 1;//Wir setzen links neben dem Start Wert neu auf. // Index belegter Treffer vorher soll der Startwert werden
                            belegteZahlen[indexBelegterTreffer] = startWert;
                                                      
                            neuBeginn = true;
                            flagge = true;
                        
                        }
                        //3 mal kein Treffer und vorher Treffer - hier wurde schon neben dem Startwert probiert und es war kiein Treffer - deshalb geht es jetzt nach oben
                        if ((neuBeginn == false || flagge == true) && zaehlerErzeugteZahlen >= 3 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 1] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 2] == 0 && zaehlerTrefferNichtTreffer[zaehlerErzeugteZahlen - 3] == 1)                                      
                        {
                            if (startWert <= spielfeldLaenge * spielfeldBreite - spielfeldLaenge) randomZahl = startWert + spielfeldLaenge;//Wir setzen oberhalb von StartWert auf wenn links daneben nicht geht // Index belegter Treffer vorher soll der Startwert werden

                            belegteZahlen[indexBelegterTreffer] = startWert;
                            neuBeginn = true;
                            flagge = false;
             
                        }

                        if (treffer == true) indexBelegterTrefferVorher = indexBelegterTreffer;
                        zaehlerErzeugteZahlen = zaehlerErzeugteZahlen + 1;

                        WurdeGetroffenRandom(randomZahl);//Methodenaufruf - hier wird geprüft ob die Random Zahl doppelt ist und ob sie in belegteZahlen[indexBelegterTreffer] íst   


                    } while (doppeltGetippt == true);
                    //Umrechnung der Random Erzeugten Zahl auf die x und y Koordinateif (belegteZahlen[indexBelegterTrefferVorher] + 1 == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] - 1
                    if (randomZahl % spielfeldLaenge > 0) xRandom = randomZahl % spielfeldLaenge;
                    if (randomZahl % spielfeldLaenge == 0) xRandom = spielfeldLaenge;

                    if (randomZahl % spielfeldLaenge > 0) yRandom = (randomZahl / spielfeldLaenge) + 1;
                    if (randomZahl % spielfeldLaenge == 0) yRandom = randomZahl / spielfeldLaenge;
                    //Ende Umrechnung der Random Erzeugten Zahl auf die x und y if (belegteZahlen[indexBelegterTrefferVorher] + 1 == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] + 1;
                    //if (belegteZahlen[indexBelegterTrefferVorher] - 1 == belegteZahlen[indexBelegterTreffer]) randomZahl = belegteZahlen[indexBelegterTreffer] - 1;

                    Console.WriteLine($"Der Computer spielt: Das war der {zaehlerTreffer}. Treffer. von {anzahlVersuche} Versuchen");
                    if (treffer == true) Console.WriteLine($"Der Computer spielt: Die Koordinaten des Treffers sind RandomZahl: {randomZahl} Länge: {xRandom} und Breite: {yRandom}");
                    if (treffer == false) Console.WriteLine($"Der Computer spielt: Die Koordinaten des NICHT " +
                        $"Treffers sind RandomZahl: {randomZahl} Länge: {xRandom} und Breite: {yRandom}");
                    
                } while (zaehlerTreffer < zaehlerbP);
            }//Ende ComputerErzeugtRandomZahl()

                
            void WurdeGetroffenRandom(int randomZahl)
            {
                doppeltGetippt = false;
                anzahlVersuche++;
                koordinaten[anzahlVersuche - 1] = randomZahl;//Jeder neue Random Wert wird in einer Tabelle gespeichert um die neuen Random Werte mit der bestehenden
                //Tabelle zu Vergleichen
                treffer = false;

                if (anzahlVersuche > 1)
                {
                    for (int i = 0; i < anzahlVersuche - 1; i++)//Der letze dazugekommene Wert wird mit allen anderen Verglichen. 
                    {
                        if (koordinaten[i] == randomZahl)//alle bisherigen Werte werden mit dem aktuellen Wert verglichen
                        {
                            doppeltGetippt = true;//Bei True werden die Treffer nicht gezählt und 
                                                  //die Anzahl Versuche wird um 1 zurückgesetzt
                            break;
                        }
                    }
                }

                for (int i = 0; i < zaehlerbP; i++) //Hier Wird geschaut ob die Random Zahl sich in der Liste der belegten Zahlen befindezt
                {
                    if ((randomZahl == belegteZahlen[i]) && doppeltGetippt == false) zaehlerTreffer++;
                    if ((randomZahl == belegteZahlen[i]) && doppeltGetippt == false) treffer = true;
                    //Wenn Zahl Treffer war dann letzte Zahl i Merken, damit der Computer dann beim nächsten Mal eine danebenliegende Zahl aussuchen kann
                    if ((randomZahl == belegteZahlen[i]) && doppeltGetippt == false) indexBelegterTreffer = i;
                    if ((randomZahl == belegteZahlen[i]) && doppeltGetippt == false) break;

                }
                if (doppeltGetippt == true) anzahlVersuche = anzahlVersuche - 1;//Anzahl Versuche werden zurückgesetzt

            }//Ende wurde geroffen Random

        }//Ende Methode Aufruf

    }//Ende Klasse
}
