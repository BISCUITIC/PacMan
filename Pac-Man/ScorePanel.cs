using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man;

internal class ScorePanel:InterfaceObject
{
    private int _score;
    public ScorePanel(Vector2i DiplayPosition):base (DiplayPosition)
    {
        _score = 0;
    }

    public void Update(int newScore)
    {
        _score = newScore;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_diplayPosition.Y, _diplayPosition.X);
        Console.Write($"score: {_score}");
    }
}
