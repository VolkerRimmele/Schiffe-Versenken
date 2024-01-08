using System.ComponentModel;
using System.Reflection.Metadata;

namespace Schiffeversenken
{
    internal class Program
    {

//Schiffeversenken.
//0. Man entschiedet zuerst, ob man ein neues Spiel machen oder das Programm beenden will.
//1. Man gibt zuerst die Anzahl der Schiffe ein, dann die Spielfeldlänge und die Spielfeldbreite. 
//    Auf der Größe des Spielfeldes basiert die Berechnung aller Felder. (z.B. bei SpielfeldLänge 10 und der Koordinate Länge 4 und Höhe 3 ist die Zahl 24)
// 2. Danach wird die Schiffslänge sowie die Schiffsbreite und die Länge bzw. Breite links unten eingegeben, die dann festlegt wo das Schiff im Koordinatensystem liegt.
// 3. Das Programm prüft, ob die eingegebenen Schiffe (bis zu 4 Stück) ins Koordinaten System passen und ob alles überschneidungsfrei ist.
// 4. Man muss so lange die Schiffe eingeben, bis alles rein passt und es keine Überschneidungen der Schiffe mehr gibt. 
// 5. Die Schiffe können als Graphik angeschaut werden.  
// 5. Der Computer erzeugt genau die gleichen Schiffe, er verteilt sie nur anders. 
// 6. Auch die Random erzeugten Schiffe müssen überschneidungsfrei sein und ins Koordination System passen. Der Computer íst so lange in einer Schleife 
//    bis die Bedingung erfüllt ist.
// 7. Auch die vom Computer erzeugten Random Schiffe können als Graphik angeschaut werden, wenn erwünscht.
// 8. Mann kann entscheiden ob man 1. nur gegen den Computer spielt 2. der Computer nur gegen einen selbst spielt oder 3. beide gegeneinnander spielen.
// 9. Der Computer räumt die Schiffe nach folgendem Algorithmus ab. 
//    a. Er geht nach dem 1. Treffer erst nach rechts und ab dem 1. Feld wo er nichts mehr findet nach unten.
//    b. Danach geht er nach links bis zu dem 1. Feld wo er nichts mehr findet, dann geht er weiter nach unten. Also immer Zickzack.
//    c. Findet er 2 mal nichts, hat also sowohl bei der Bewegung in der Länge als auch in der Breite keinen Treffer, setzt er links neben dem allerersten Treffer
//       auf. Falls es an dieser Stelle keinen Treffer gibt, geht er nach oben und dann erstmal nach rechts. Das ganze geht Zickzack weiter immer in
//       Richtung nach oben. Auf diese Weise kann ein Schiff komplett abgeräumt werden.
//10. Am Schuß kann man entscheiden, ob man das Spiel beenden oder noch eine Runde spielen will.   

        static void Main(string[] args)
        {
            Menuefuehrung.Menuefuehrung2();
            return;
        }
    }
}