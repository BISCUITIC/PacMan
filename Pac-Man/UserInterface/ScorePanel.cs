using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;

namespace Pac_Man.UserInterface;

internal class ScorePanel : InterfaceObject
{
    private int _score;
    public ScorePanel(Vector2i DiplayPosition) : base(DiplayPosition)
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
