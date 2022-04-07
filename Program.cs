using System;
using System.Linq;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("ERROR: Wrong input arguments \n" +
                                  "Make sure inputting odd number of arguments more than 2!");
                return;
            }
            
            if(args.Distinct().Count() != args.Count())
            {
                Console.WriteLine("ERROR: Wrong input arguments \n" +
                                  "Make sure there are no identical arguments!");
                return;
            }

            var table = new Tablegen(args);
            table.GenerateTable();


            var rng = new Random();
            int cmpchoice = rng.Next(0, args.Length - 1);
            var keygenerator = new Keygen();
            var secretkey = keygenerator.GetKey();
            var hmacgenerator = new HMACgen(args[cmpchoice], secretkey);
            string HMAC = hmacgenerator.ShowHash();
            string key = keygenerator.ShowKey();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"HMAC: {HMAC}");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {args[i]}");
                }
                Console.WriteLine("? - help");
                Console.WriteLine("0 - exit");
                Console.Write("Enter your move: ");

                string input = Console.ReadLine();

                if (input == "?")
                {
                    Console.Clear();
                    table.ShowTable();
                    Console.WriteLine("\nPress any button to continue...");
                    Console.ReadKey();
                }                    

                try
                {
                    int test = Convert.ToInt32(input);
                }
                catch
                {
                    Console.Clear();
                    continue;
                }
                int hmnchoice = Convert.ToInt32(input);

                if (hmnchoice > 0 && hmnchoice < args.Length)
                {
                    var game = new Game(table.GetTable(), cmpchoice, hmnchoice);
                    Console.WriteLine($"Your move: {args[hmnchoice - 1]}");
                    Console.WriteLine($"Computer move: {args[cmpchoice]}");

                    if(game.GetResult() == "Draw")
                        Console.WriteLine("Draw!");
                    else
                        Console.WriteLine($"You {game.GetResult()}!");

                    Console.WriteLine($"HMAC key: {key}");
                    exit = true;
                }
                else
                {
                    Console.Clear();
                }

                if (input == "0")
                    exit = true;
            }
        }
    }
}
