namespace IdleMiner
{
    class MiningSystem
    {
        private Player playerInst {get; set;}
        private Base baseInst {get; set;}
        private Random randomizer= new Random();


        public MiningSystem(Player pI, Base bI)
        {
            playerInst=pI;
            baseInst=bI;
        }

        public void Mine()
        {
            switch (playerInst.Equipment)
            {
                case "Pickaxe":
                    {
                        long randomRock=randomizer.Next(1,5);
                        Console.WriteLine($"You have mined {randomRock} rocks with your pickaxe!");
                        baseInst.addtoStorage(rock: randomRock);
                        break;
                    }

                case "Drill":
                    {
                        long randomRock=randomizer.Next(1,8);
                        long randomIronOre=randomizer.Next(1,5);
                        long randomCopperOre=randomizer.Next(1,3);
                        Console.WriteLine($"You have mined {randomRock} rocks, {randomIronOre} iron ore and {randomCopperOre} copper ore with your drill!");
                        baseInst.addtoStorage(rock: randomRock, ironore:randomIronOre, copperore:randomCopperOre);
                        break; 
                    }


                case "Excavator":
                    {
                        long randomRock=randomizer.Next(5,25);
                        long randomIronOre=randomizer.Next(5,15);
                        long randomCopperOre=randomizer.Next(5,10);
                        long randomDiamondOre=randomizer.Next(1,5);
                        Console.WriteLine($"You have mined {randomRock} rocks, {randomIronOre} iron ore, {randomCopperOre} copper ore and {randomDiamondOre} diamond ore with your excavator!");
                        baseInst.addtoStorage(rock: randomRock, ironore:randomIronOre, copperore:randomCopperOre, diamondore:randomDiamondOre);
                        break;
                    }
                
                case "Quarry":
                    {
                        long randomRock=randomizer.Next(10,30);
                        long randomIronOre=randomizer.Next(10,20);
                        long randomCopperOre=randomizer.Next(10,20);
                        long randomDiamondOre=randomizer.Next(5,10);
                        long randomViltrumOre=randomizer.Next(1,3);
                        Console.WriteLine($"You have mined {randomRock} rocks, {randomIronOre} iron ore, {randomCopperOre} copper ore, {randomDiamondOre} diamond ore and {randomViltrumOre} viltrum ore with your quarry!");
                        baseInst.addtoStorage(rock: randomRock, ironore:randomIronOre, copperore:randomCopperOre, diamondore:randomDiamondOre, viltrumore:randomViltrumOre);
                        break;
                    }


            }
        }

        public void ValuableMine()
        {
            int randomPercCompare=randomizer.Next(1,101);
            int randomIndex=randomizer.Next(0,4);
            string[] Ores= ["Yakhadur Ore", "Big R Ore", "Appalachian Ore", "Mink Ore"];

            if (playerInst.ValuablePerc >= randomPercCompare)
            {
                switch (randomIndex)
                {
                    case 0:
                        baseInst.addtoStorage(yakhadurore:1);
                        break;
                    case 1:
                        baseInst.addtoStorage(bigrore:1);
                        break;
                    case 2:
                        baseInst.addtoStorage(appalachianore:1);
                        break;
                    case 3:
                        baseInst.addtoStorage(minkore:1);
                        break;
                }
                Console.WriteLine($"Woah, you mined one {Ores[randomIndex]} with your {playerInst.Equipment}");
            }
        }


    }
}