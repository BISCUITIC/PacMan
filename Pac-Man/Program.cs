using Pac_Man.Entities;
using Pac_Man.UserInterface;
using System.Text;
using System.Collections.Generic;
using Pac_Man.Interfaces;

namespace Pac_Man;

internal class Program
{
    private static bool gameOver = false;
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Map map = new Map();
        Player player = new Player((21, 12), map);        
        Enemy enemy1 = new Enemy((10, 13), player, GameOver);
        ScorePanel scorePanel = new ScorePanel((0, 27), player);


        List<IDrawable> drawableList = new List<IDrawable>();
        drawableList.Add(map);
        drawableList.Add(scorePanel);
        drawableList.Add(player);
        drawableList.Add(enemy1);

        List<IUpdatable> updatableList = new List<IUpdatable>();
        updatableList.Add(scorePanel);
        updatableList.Add(enemy1);
        updatableList.Add(player);
        

        while (!gameOver)
        {
            foreach (IUpdatable item in updatableList)
                item.Update();

            foreach (IDrawable item in drawableList)
                item.Draw();

            Task.Delay(200).Wait();
        }

        Console.SetCursorPosition(0, map.Size);
    }

    private static void GameOver()
    {
        gameOver = true;
    }
}
