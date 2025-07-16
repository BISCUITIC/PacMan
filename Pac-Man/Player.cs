namespace Pac_Man;

internal class Player : Entity, IDrawable
{
    private readonly Map _map;
    private readonly char _symbol;

    private readonly PlayerMovementController _playerMovementController;

    public Player(Map map, Vector2i position) : base(position)
    {
        _map = map;
        _symbol = '$';
        _playerMovementController = new PlayerMovementController();
    }

    public void Update()
    {
        _playerMovementController.Update();

        CheckCollisions();
    }

    private void CheckCollisions()
    {
        Vector2i targetPosition = _position + _playerMovementController.Direction;
        if (IsInsideMap(targetPosition) && _map[targetPosition.X, targetPosition.Y] == Map.EmptySymbol)
        {
            _position = targetPosition;               
        }
    }

    private bool IsInsideMap(Vector2i position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < _map.Size && position.Y < _map.Size;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write(_symbol);
    }
}
