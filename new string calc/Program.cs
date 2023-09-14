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

            string[] ops = { "+", "-", "*", "/", "%"};
            string[] numf = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ",", ".", " "};


            //-------------------------
            //Variables
            //-------------------------

            Console.WriteLine("Bitte die Formel mit unendlich vielen Zahlen eingeben");
            string input = Console.ReadLine();
            bool fail = false;
            int counter = 0;
            double res = 0;

            //-------------------------
            //Error finding
            //-------------------------


            foreach (char c in input)
            {
                if (c >= 58 && c <=126 || c >= 33 && c <= 36) //ASCII Table wird genutzt ob der char den Zahlen Value von dem jeweiligen Zeichen im ASCII Table hat.
                {
                    fail = true; //setzt fail == true damit while schleife nächste instanz geht. Wusste nicht wie ich von hier aus sonst breaken soll.
                    break;
                }
            }
            
            if (fail || input == String.Empty) // fail == true oder empty input == continue and error handling.
            {
                Console.WriteLine("Fehler: Falsches oder kein Zeichen eingegeben");
                continue;
            }

            if (input.Contains("/0"))
            {
                Console.WriteLine("Fehler: Du darfst nicht durch 0 teilen.");
                continue;
            }

            //-------------------------------
            //Storage Arrays to use later
            //-------------------------------

            string[] tempNumStorage = input.Split(ops, StringSplitOptions.RemoveEmptyEntries);
            string[] tempOpStorage = input.Split(numf, StringSplitOptions.RemoveEmptyEntries);

            //-------------------------
            //Exception finding
            //-------------------------

            //Fehler bei zu wenigen Eingaben oder doppelt Operatoren Eingaben.

            foreach (string s in tempOpStorage)
            {
                if (s.Length > 1)
                {
                    fail = true; break;
                }
            }

            if (fail) // fail == true oder leere eingabe == continue und fehlermeldung.
            {
                Console.WriteLine("Fehler: Du hast zwei Zeichen aufeinmal eingegeben");
                continue;
            }

            if (tempNumStorage.Length < 2)
            {
                Console.WriteLine("Fehler: Du hast nur eine oder zu viele Zahlen eingegeben.");
                continue;
            }

            //-------------------------------
            //Storage Lists to use later
            //-------------------------------

            List<double> numStorage = new List<double>(); //Erstellung von einer List um Werte besser zu nutzen
            List<string> opStorage = new List<string>(); //Aufbewahrung Operatoren
            List<string> tempStorage = new List<string>(); //Um Operatoren nicht löschen zu müssen später

            //-------------------------------
            //Storage filling
            //-------------------------------

            foreach (string num in tempNumStorage)
            {
                numStorage.Add(Convert.ToDouble(num));
            }

            foreach (string op in tempOpStorage)
            {
                opStorage.Add(op);
            }

            //-------------------------------
            //Calculation
            //-------------------------------

            foreach (string op in opStorage)
            {
                if (op == "*")
                {
                    res = numStorage[counter] * numStorage[counter + 1];
                    numStorage.RemoveRange(counter, 2);
                    numStorage.Insert(counter, res);
                }
                else if (op == "/")
                {
                    res = numStorage[counter] / numStorage[counter + 1];
                    numStorage.RemoveRange(counter, 2);
                    numStorage.Insert(counter, res);
                }
                else if (op == "+" || op == "-")
                {
                    tempStorage.Add(op);
                    counter++;
                }
                else { counter = 0; break; }
            }
            counter = 0;
            opStorage.Clear();
            opStorage.AddRange(tempStorage);

            foreach (string op in opStorage)
            {
                if (counter == 0)
                {
                    if (op == "+")
                    {
                        res = numStorage[counter] + numStorage[counter + 1];
                        numStorage.RemoveRange(counter, 2);
                        counter++;
                    }
                    else
                    {
                        res = numStorage[counter] - numStorage[counter + 1];
                        numStorage.RemoveRange(counter, 2);
                        counter++;
                    }
                }
                else if (op == "+")
                {
                    res += numStorage[0];
                    counter++;
                }
                else if (op == "-")
                {
                    res -= numStorage[0];
                    counter++;
                }
                else { break; }
            }

            //-------------------------
            //Ergebnis
            //-------------------------

            Console.WriteLine($"Das Ergebnis von {input} lautet = {Math.Round(res, 2)}");
         }
    }
}