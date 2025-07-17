using Pac_Man.CoordinatesSystem;

namespace Pac_Man.Entities;

internal class PlayerMovementController
{
    private ConsoleKeyInfo _lastKeyPressed;

    public Vector2i Direction { get; set; }

    public PlayerMovementController()
    {
        _lastKeyPressed = new ConsoleKeyInfo();
        Direction = Vector2i.Zero;
    }

    public void Update()
    {
        while (Console.KeyAvailable)
        {
            _lastKeyPressed = Console.ReadKey(true);
        }

        switch (_lastKeyPressed.Key)
        {
            case ConsoleKey.W:
                Direction = (-1, 0);
                break;
            case ConsoleKey.S:
                Direction = (1, 0);
                break;
            case ConsoleKey.A:
                Direction = (0, -1);
                break;
            case ConsoleKey.D:
                Direction = (0, 1);
                break;
        }
    }
}
