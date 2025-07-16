

using System.Text;

namespace Pac_Man;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Map map = new Map();
        Player player = new Player(map, (1,1));
        ScorePanel scorePanel = new ScorePanel((0, 20));

        player.ScoreChanged += scorePanel.Update;

        while (true)
        {
            player.Update();

            scorePanel.Draw();
            map.Draw();
            player.Draw();

            Task.Delay(200).Wait();
        }
    }
}
