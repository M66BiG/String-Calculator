using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            //-------------------------
            //Condition Arrays
            //-------------------------

            // String Array damit es im .Split die Vorgabe erfüllt eines string[], ansonsten wäre natürlich char[] besser.
            string[] ops = { "+", "-", "*", "/","%"};
            string[] numf = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",",",".", " " };
            //string[] chars = { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" }; // hatte keine lust

            
            //-------------------------
            //Variablen
            //-------------------------
            Console.WriteLine("Bitte die Formel mit 2 Zahlen eingeben");
            string input = Console.ReadLine();
            bool fail = false;

            //-------------------------
            //Fehlersuche
            //-------------------------


            foreach (char c in input)
            {
                if (c >= 58 && c <=126 || c >= 33 && c <= 36) //ASCII Table wird genutzt ob der char den Zahlen Value von dem jeweiligen Zeichen im ASCII Table hat.
                {
                    fail = true; //setzt fail == true damit while schleife nächste instanz geht. Wusste nicht wie ich von hier aus sonst breaken soll.
                    break;
                }
            }
            
            
            if (fail || input == String.Empty) // fail == true oder leere eingabe == continue und fehlermeldung.
            {
                Console.WriteLine("falsches oder kein Zeichen eingegeben");
                continue;
            }

            //-------------------------------
            //storage Arrays zum weiternutzen
            //-------------------------------

            string[] numstorage = input.Split(ops, StringSplitOptions.RemoveEmptyEntries);
            string[] opstorage = input.Split(numf, StringSplitOptions.RemoveEmptyEntries);

            //Fehler bei zu wenigen Eingaben.
            
            if (numstorage.Length < 2 || numstorage.Length > 2)
            {
                Console.WriteLine("Fehler: Du hast nur eine oder zu viele Zahlen eingegeben.");
                continue;
            }

            //-------------------------
            //Variablen zum Rechnen
            //-------------------------
            

            double n1 = Convert.ToDouble(numstorage[0]);
            double n2 = Convert.ToDouble(numstorage[1]);
            double res = 0;

            //-------------------------
            //Conditional Calculating
            //-------------------------

            switch (opstorage[0])
            {
                case "+":
                    res = n1 + n2;
                    break;
                case "-":
                    res = n1 - n2;
                    break;
                case "*":
                    res = n1 * n2;
                    break;
                case "/":
                    res = n1 / n2;
                    break;
                case "%":
                    res = n1 % n2;
                    break;
                default:
                    break;
            }

            //-------------------------
            //Ergebnis
            //-------------------------
            Console.WriteLine($"Das Ergebnis von {input} lautet = {Math.Round(res, 2)}");
        }
    }
}