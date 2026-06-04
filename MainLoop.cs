
namespace IdleMiner;

class Program
{
    static async Task Main(string[] args)
    {
        
        Player pInst = new Player();
        Base bInst = new Base();
        MiningSystem mining = new MiningSystem(pInst, bInst);
        SellStore sell = new SellStore(pInst, bInst);
        BuyStore buy = new BuyStore(pInst, bInst);

        Game game = new Game(pInst, bInst, mining, sell, buy);
        await game.Run(); // Don't forget 'await' since Run() is an async Task!

    }
}
