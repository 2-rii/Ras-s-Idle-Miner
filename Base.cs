//ts place will have the Base and Player details

namespace IdleMiner
{
    class Player
    {
        public long Money{get; private set;}
        public int DaysPassed{get; private set;}
        public string Equipment{get; private set;}
        public long MiningSpeedModifier{get; private set;}
        public long ValuablePerc{get; private set;}

        public Player()
        {
            Money=0;
            DaysPassed=0;
            Equipment="Pickaxe";
            MiningSpeedModifier=5;
            ValuablePerc=2;
        }

        public Player(long money, int daysPassed, string equipment, long miningSpeed, long valuablePerc)
        {
            Money=money;
            DaysPassed=daysPassed;
            Equipment=equipment;
            MiningSpeedModifier=miningSpeed;
            ValuablePerc=valuablePerc;
        }

        public void increaseMoney(long Increase)
        {
            Money+=Increase;
        }

        public void decreaseMoney(long Decrease)
        {
            Money-=Decrease;
        }

        public void ChangeEquip(string newName, long newSpeed, long newValPerc)
        {
            Equipment=newName;
            MiningSpeedModifier=newSpeed;
            ValuablePerc=newValPerc;
        }

        public void PassDay()
        {
            DaysPassed++;
        }

        public bool checkMoney(long Amount)
        {
            return Amount<=Money;
        }



    }

    class Base
    {
        public long MaxCapacity{get; private set;}
        public Dictionary<string,long> CurrentStorage {get; private set;}

        public Base()
        {
            MaxCapacity=1000;
            CurrentStorage= new Dictionary<string, long>
            {
                ["Rocks"]= 0,
                ["Iron Ore"]=0,
                ["Copper Ore"]=0,
                ["Gold Ore"]=0,
                ["Diamond Ore"]=0,
                ["Viltrum Ore"]=0,
                ["Yakhadur Ore"]=0,
                ["Big R Ore"]=0,
                ["Appalachian Ore"]=0,
                ["Mink Ore"]=0
            };
        }

        public Base(long maxCapacity, Dictionary<string,long> currentStorage)
        {
            MaxCapacity=maxCapacity;
            CurrentStorage=currentStorage;
        }

        public long getTotal()
        {
            long total=0;
            foreach(var(ore, quantity) in CurrentStorage)
            {
                total+=quantity;
            }
            return total;
        }

        public bool checkifFull(long total)
        {

            return total >= MaxCapacity; 

        }

        public bool addtoStorage(long rock=0, long ironore=0, long copperore=0, long goldore=0, long diamondore=0, long viltrumore=0, long yakhadurore=0, long bigrore=0, long appalachianore=0, long minkore=0)
        {
            if (checkifFull(getTotal()))
            {
                return false;
            }
            else
            {
                //You can go over the storage limit, only cuz im too lazy to implement a system to equally distribute if full
                CurrentStorage["Rocks"]+=rock;
                CurrentStorage["Iron Ore"]+=ironore;
                CurrentStorage["Copper Ore"]+=copperore;
                CurrentStorage["Gold Ore"]+=goldore;
                CurrentStorage["Diamond Ore"]+=diamondore;
                CurrentStorage["Viltrum Ore"]+=viltrumore;
                CurrentStorage["Yakhadur Ore"]+=yakhadurore;
                CurrentStorage["Big R Ore"]+=bigrore;
                CurrentStorage["Appalachian Ore"]+=appalachianore;
                CurrentStorage["Mink Ore"]+=minkore;
                return true;
            }
        }

        public void inittoZero()
        {
            CurrentStorage["Rocks"]=0;
            CurrentStorage["Iron Ore"]=0;
            CurrentStorage["Copper Ore"]=0;
            CurrentStorage["Gold Ore"]=0;
            CurrentStorage["Diamond Ore"]=0;
            CurrentStorage["Viltrum Ore"]=0;
            CurrentStorage["Yakhadur Ore"]=0;
            CurrentStorage["Big R Ore"]=0;
            CurrentStorage["Appalachian Ore"]=0;
            CurrentStorage["Mink Ore"]=0;
        }

        public Dictionary<string,long> getStorage()
        {
            //Rare case when storage needs to be looked into, like for selling
            return CurrentStorage;
        }


    }
}