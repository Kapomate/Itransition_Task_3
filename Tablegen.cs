using System;

namespace Task3
{
    class Tablegen
    {
        private string[] vallues;
        private int vlength = 0;
        private string[,] rulestable;

        public Tablegen(string[] input)
        {
            vallues = input;
            vlength = vallues.Length;
        }

        public void Setvallues(string[] input)
        {
            vallues = input;
            vlength = vallues.Length;
        }

        public void GenerateTable()
        {
            rulestable = new string[this.vlength + 1, this.vlength + 1];
            rulestable[0, 0] = "....";
            int wincol = (vlength - 1) / 2;

            for (int i = 1; i <= vlength; i++)
            {
                rulestable[0, i] = vallues[i - 1];
                rulestable[i, 0] = vallues[i - 1];
            }

            for (int i = 1; i <= vlength; i++)
            {
                for(int j = 1; j <= vlength; j++)
                {
                    if (j > i && j <= (i + wincol))
                         rulestable[i, j] = "Win ";
                    else if (j < i && j < (i - wincol))
                         rulestable[i, j] = "Win ";
                    else rulestable[i, j] = "Lose";

                    if (i == j)
                        rulestable[i, j] = "Draw";
                }
            }
        }
        
        public void ShowTable()
        {
            int interval = 4;

            for (int i = 0; i < vlength; i++)
            {
                if (interval < vallues[i].Length)
                    interval = vallues[i].Length;
            }

            string outpform = String.Format("{{0, {0}}}", interval);

            for (int i = 0; i < vlength + 1; i++)
            {
                for (int j = 0; j < vlength + 1; j++)
                {
                    Console.Write(outpform, rulestable[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public string[,] GetTable()
        {
            return rulestable;
        }
    }
}
