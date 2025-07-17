using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Entities;
using Pac_Man.Interfaces;

namespace Pac_Man.UserInterface;

internal class ScorePanel : InterfaceObject, IUpdatable, IDrawable
{
    private int _score;
    private readonly Player _player;
    public ScorePanel(Vector2i DiplayPosition, Player plyer) : base(DiplayPosition)
    {
        _player = plyer;
        _score = 0;
    }

    public void Update()
    {
        _score = _player.Score;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_diplayPosition.Y, _diplayPosition.X);
        Console.Write($"score: {_score}");
    }
}
