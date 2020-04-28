using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            //o1d1();
            //o1d2();
            //o1d3();

            //o2d1();
            //o2d2();
            o2d3();

            void o1d1()
            {
                Console.Clear();
                //1.1 Udregn temperaturen i Celsius ud fra temperaturen i Fahrenheit
                Console.WriteLine("Indtast en temperatur i Fahrenheit: ");
               
                double fahrenheit = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                double celsius = Math.Round((fahrenheit - 32) * 5 / 9, 2);
                Console.WriteLine("{0} grader Fahrenheit svare til {1} grader Celcius", fahrenheit, celsius);
                Console.ReadKey();


            }
            void o1d2()
            {
                Console.Clear();
                //1.2 Udregn temperaturen i andre enheder ud fra Celsius
                Console.WriteLine("Indtast en temperatur i Celsius: ");
                double celsius = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                double fahrenheit = Math.Round((celsius * 9 / 5) + 32, 1);
                double kelvin = Math.Round(celsius + 273.15, 1);
                double reaumur = Math.Round(celsius * 0.8, 1);
                Console.WriteLine("{0}°\n{1}°\n{2}°\n{3}°", celsius, fahrenheit, kelvin, reaumur);
                Console.SetCursorPosition(7, 0); Console.WriteLine("Celsius");
                Console.SetCursorPosition(7, 1); Console.WriteLine("Fahrenheit");
                Console.SetCursorPosition(7, 2); Console.WriteLine("Kelvin");
                Console.SetCursorPosition(7, 3); Console.WriteLine("Réaumur");
                Console.ReadKey();
            }
            void o1d3()
            {
                Console.Clear();
                //1.3 Valutaomregning
                while (true)
                {
                    // mine variabler som bruges på tværs af loops defineres her.
                    string units;
                    string[] input;
                    double startingAmount;
                    double exchange_rate;

                    while (true)// while-loop der skal sikre sig at det kun er det gyldige format der bliver omregnet, ellers bliver man prompted med input igen.
                    {

                        try // try catch rundt om brugerens input i tilfælde af f.eks. forkert input type.
                        {
                            while (true) // while-loop som skal sikre sig at der er indtastet 100 enheder eller flere.
                            {
                                Console.Write("Format: 100 USD\nIndtast beløb: ");
                                units = Console.ReadLine();
                                input = units.Split(' '); // splitter inputtet op på mellemrummet, og gemmer det i string arrayet input.
                                if (Convert.ToDouble(input[0]) < 100) // index 0 i input arrayet er tallet brugeren har indtastet.
                                {
                                    Console.Clear();
                                    Console.Write("Du kan ikke væksle mindre end 100 enheder."); // fejlbesked
                                }
                                else { break; } // hvis enhederne ikke er under 100, kan programmet forsætte med udregningerne.
                            }
                            startingAmount = Convert.ToDouble(input[0]); // gemmer tallet fra input som egen værdi, bruges til udregningen.
                            exchange_rate = 0.0;
                            if (input[1].ToUpper() == "USD") { exchange_rate = 687.35; break;  } // hvis andet parameter i brugerens input er USD, sættes raten herefter
                            else if (input[1].ToUpper() == "EUR") { exchange_rate = 745.91; break; } // og loopet breakes (altså formateringen er godkendt).
                            else if (input[1].ToUpper() == "GBP") { exchange_rate = 854.78; break; } // samme gælder også for EUR og GBP
                            else // fejl-catching,
                            {
                                Console.Write("Fejl i formattet. Tryk på en knap for at forsøge igen.");
                                Console.ReadKey();
                            }
                        }
                        catch 
                        {
                            Console.Write("Fejl i formattet. Tryk på en knap for at forsøge igen.");
                            Console.ReadKey();
                        }
                        Console.Clear();
                    }
                    double result = Math.Round(startingAmount * exchange_rate / 100, 1); // valutaomregningsformlen. 
                    Console.Clear();
                    Console.Write("Vækslekurs: {0}\n\n{2} {1} enheder\n\nudbetalt: {3} DKK",exchange_rate, startingAmount, input[1], result); // resultatet udskrives.
                    break; // main loopet brydes om programmet forsætter
                }
            }

            void o2d1()
            {
                Console.Clear();
                //2.1 Udskrivning af tekst på baggrund af input
                Console.WriteLine("indtast venligst dit navn og alder");
                string[] input = Console.ReadLine().Split(' ');
                int age = Convert.ToInt32(input[1]);
                // man burde her tilføje en masse sikkerhed af input typer mm. men dette har jeg valgt at springe over.
                Console.Write("Dit navn er {0}, du er {1} år gammel og ",input[0],age);
                if (age == 1) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("du er lige født"); }
                else if (age >= 2 && age <= 5) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("du kan begynde i børnehave"); }
                else if (age >= 6 && age <= 16) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("du går i skole"); }
                else if (age > 16) { Console.ForegroundColor = ConsoleColor.Blue; Console.Write("nu begynder alvoren"); }
                else { Console.Write("du er 0 år..."); } //opgaven tager ikke højde for at man kan være 0 år, i stedet er man lige blevet født ved 1 års alderen?
            }
            void o2d2()
            {
                while (true)
                {
                    Console.Clear();
                    //2.2 Navn på dag i ugen
                    Console.Write("Format: 1 = mandag, 2 = tirsdag osv.\nAgiv dag nr i ugen: ");
                    int input = Convert.ToInt32(Console.ReadLine());

                    // Der er her ingen behov for at lave nested if-statements, det kan ungås meget nemt i dette tilfælde, f.eks. med at bruge et string array til navne. 
                    if (input > 0 && input <= 7) {
                        string[] days = { "", "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };
                        Console.Clear();
                        Console.WriteLine("I dag er det " + days[input]);
                        break;
                    }
                }
            }
            void o2d3()
            {
                Console.Clear();
                //2.3 Udregning af rabatsats og totalpris
                Console.WriteLine("indtast venligst pirs pr. stk og antal");
                string[] input = Console.ReadLine().Split(' ');
                double price = Convert.ToDouble(input[0]); //første element i input arrayet er stk prisen altså et kommatal
                int units = Convert.ToInt32(input[1]) ;// andet element i input arrayet er mængden af enheder altså et heltal
                int discount_rate = 0; // rabat %
                if (units <= 100) { discount_rate = 0; }
                else if (units > 100 && units <= 200) { discount_rate = 5; }
                else if (units > 200 && units <= 400) { discount_rate = 8; }
                else if (units > 400 && units <= 700) { discount_rate = 10; }
                else if (units > 700 ) { discount_rate = 15; }
                else
                {
                    Console.WriteLine("Der er sket en fejl. Tryk på en tast");
                    Console.ReadKey();
                }

                Console.Clear();
                Console.WriteLine("Pris før rabat: {0}\nRabat: {1}%\nPris efter rabat: {2}",Math.Round(units*price,2),discount_rate,(Math.Round(units * price-((units*price/100)*discount_rate),2)));
            }

            Console.ReadKey();
        }
    }
}
