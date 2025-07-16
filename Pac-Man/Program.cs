using Pac_Man.Entities;
using Pac_Man.UserInterface;
using System.Text;
using System.Collections.Generic;

namespace Pac_Man;

internal class Program
{
    private static bool gameOver = false;
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Map map = new Map();
        Player player = new Player(map, (21, 12));
        ScorePanel scorePanel = new ScorePanel((0, 27));

        List<Enemy> enemyList = new List<Enemy>();
        enemyList.Add(new Enemy((10, 13), player));
        //enemyList.Add(new Enemy((10, 11), player));
        //enemyList.Add(new Enemy((12, 11), player));
        //enemyList.Add(new Enemy((12, 13), player));

        player.ScoreChanged += scorePanel.Update;
        foreach (Enemy enemy in enemyList)
            enemy.CaughtUpPlayer += GameOver;                


        while (!gameOver)
        {
            
            player.Update();
            foreach (Enemy enemy in enemyList)
                enemy.Update();

            scorePanel.Draw();
            map.Draw();
            player.Draw();
            foreach (Enemy enemy in enemyList)
                enemy.Draw();


            Task.Delay(200).Wait();
        }
    }

    private static void GameOver()
    {
        gameOver = true;
    }
}
