using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffeversenken
{
    internal class Menuefuehrung
    {

        public static void Menuefuehrung2()
        {
            int eingabeZahl;//Die vom User eingegebene Zahl
            bool check;

            do
            {
                Console.WriteLine("Was möchten Sie Tun, 1=neues Spiel, 2 =Programm beenden");
                check = int.TryParse(Console.ReadLine(), out eingabeZahl);//Check wird true wenn Konvertierung zu int erfolgreich

                switch (eingabeZahl)
                {
                    case 1:
                        User.Menue();
                        break;
                    case 2:
                        return;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte 1-2 eingeben, 1=neues Spiel, 2=Programm beenden");
                        Console.Clear();
                        break;
                }

            } while (check == false || eingabeZahl < 2 || eingabeZahl > 2);//Schleife wird nur verlassen wenn 2 eingegeben wird
        }

    }
}
