using System.Threading.Tasks;
namespace IdleMiner
{
    class Game
    {
        private Player playerInst{get; set;}
        private Base baseInst{get; set; }
        private MiningSystem miningSys{get; set;}
        private SellStore sellInst{get; set;}
        private BuyStore buyInst{get; set;}
        private string[] Equip=["Pickaxe", "Drill", "Excavator", "Drill"];
        private bool running{get; set;}


        public Game(Player pI, Base bI, MiningSystem mI, SellStore sI, BuyStore bSI)
        {
            playerInst=pI;
            baseInst=bI;
            miningSys=mI;
            sellInst=sI;
            buyInst=bSI;
        }

        public async Task Run()
        {
            running=true;
            DateTime lastMine= DateTime.Now;
            Console.CursorVisible=false;

            do
            {
                if ((DateTime.Now - lastMine).TotalSeconds >= 1)
                {
                    miningSys.Mine();
                    miningSys.ValuableMine();
                    lastMine=DateTime.Now;
                    printDisplay();
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    HandleInput(keyInfo);
                }

                await Task.Delay(16);

            }while (running);
        }

        public void printDisplay()
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("               Ras's Idle Miner             ");
            Console.WriteLine("============================================");
            Console.WriteLine($"Current Money: {playerInst.Money}      ");
            Console.WriteLine($"Current Equipment: {playerInst.Equipment}");
            Console.WriteLine($"Base Storage: {baseInst.getTotal()} / {baseInst.MaxCapacity}");
            Console.WriteLine($"Current Ores:\n Rocks({baseInst.CurrentStorage["Rocks"]}),\n Iron Ore({baseInst.CurrentStorage["Iron Ore"]}),\n Copper Ore({baseInst.CurrentStorage["Copper Ore"]}),\n Gold Ore({baseInst.CurrentStorage["Gold Ore"]}),\n Diamond Ore({baseInst.CurrentStorage["Diamond Ore"]}),\n Viltrum Ore({baseInst.CurrentStorage["Viltrum Ore"]}),\n Yakhadur Ore({baseInst.CurrentStorage["Yakhadur Ore"]}),\n Big R Ore({baseInst.CurrentStorage["Big R Ore"]}),\n Appalachian Ore({baseInst.CurrentStorage["Appalachian Ore"]}),\n Mink Ore({baseInst.CurrentStorage["Mink Ore"]}) ");
            Console.WriteLine("============================================");
            Console.WriteLine($"Press [P] to Save and Exit        ");
            Console.WriteLine($"Press [S] to Load your previous game");
            Console.WriteLine($"Press [K] to Open the Shop");
            Console.WriteLine($"Press [Y] to Sell your ores");
            Console.WriteLine("============================================");

        }

        public void HandleInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.P:
                    running=false;
                    Console.Clear();
                    Console.WriteLine("You may leave Ras's Miner, but Ras's Miner will never leave you");
                    Console.CursorVisible=true;
                    //Save Logic Here
                    break;
                
                case ConsoleKey.S:
                    //Load Logic here
                    break;
                
                case ConsoleKey.K:
                    Console.Clear();
                    //Display Shop
                    //Exit and come back
                    break;
                
                case ConsoleKey.Y:
                    sellInst.SellAll();
                    break;
            }
        }
    }
}