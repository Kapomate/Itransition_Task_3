namespace Task3
{
    class Game
    {
        private string[,] rulestable;
        int cmpchoice;
        int hmnchoice;

        public Game(string[,] rules, int cc, int hc)
        {
            rulestable = rules;
            cmpchoice = cc + 1;
            hmnchoice = hc;
        }

        public string GetResult()
        {
            return rulestable[hmnchoice, cmpchoice];
        }

        //Ther could be your:
        //public <> get...()
        //public void set(<> a)
        //... but it's not necessary rigth now
    }
}
