
namespace IdleMiner
{
    class SellStore
    {
        private Dictionary<string,long> SellPairs{get;  set;}
        private Player playerInst {get; set;}
        private Base baseInst {get; set;}

        public SellStore(Player pI, Base bI)
        {
            playerInst=pI;
            baseInst=bI;

            SellPairs =new Dictionary<string, long>{
                ["Rocks"]= 1,
                ["Iron Ore"]=3,
                ["Copper Ore"]=5,
                ["Gold Ore"]=7,
                ["Diamond Ore"]=15,
                ["Viltrum Ore"]=20,
                ["Yakhadur Ore"]=30,
                ["Big R Ore"]=60,
                ["Appalachian Ore"]=40,
                ["Mink Ore"]=50
            };
        }

        public void SellAll()
        {
            Dictionary<string,long> CurrentStorage=baseInst.getStorage();
            long total=0;

            foreach(var(ore, quantity) in CurrentStorage)
            {
                total+= SellPairs[ore]*CurrentStorage[ore];
            }

            baseInst.inittoZero();
            playerInst.increaseMoney(total);
            Console.WriteLine($"Congratulations! You have earned {total} by selling all of your ores");
        }
    }

    class BuyStore
    {
        private Player playerInst{get; set;}
        private Base baseInst{get; set;}
        private Dictionary<string,long[]> shop = new Dictionary<string, long[]>
        {
            // Price, Mining Speed, Valuable Percentage
            ["Drill"]=[100,10,5],
            ["Excavator"]=[800,20,8],
            ["Quarry"]=[2000,40,10]
        };

        public BuyStore(Player pI, Base bI)
        {
            playerInst=pI;
            baseInst=bI;
        }

        public void Buy(string Item)
        {
            if (playerInst.checkMoney(shop[Item][0]))
            {
                playerInst.ChangeEquip(Item, shop[Item][1], shop[Item][2]);
                playerInst.decreaseMoney(shop[Item][0]);
            }
            else
            {
                Console.WriteLine("You aint nothing but a broke boy, boy.");
            }
        }
    }
}
