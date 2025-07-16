

namespace Pac_Man;

internal class Program
{
    static void Main(string[] args)
    {
        Map map = new Map();
        Player player = new Player(map, (1,1));
             
        while (true)
        {
            player.Update();
            map.Draw();
            player.Draw();

            Task.Delay(200).Wait();
        }
    }
}
