namespace Pac_Man;

internal class Player : Entity, IDrawable
{
    private readonly Map _map;    
    
    private readonly PlayerMovementController _playerMovementController;

    private int _score;

    public delegate void Change(int newValue);
    public event Change ScoreChanged;

    public Player(Map map, Vector2i startPosition) : base(startPosition)
    {
        _map = map;        
        _score = 0;
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

        if (!IsInsideMap(targetPosition)) return;

        if (_map[targetPosition.X, targetPosition.Y] == Map.EmptySymbol)
        {
            _position = targetPosition;               
        }
        if (_map[targetPosition.X, targetPosition.Y] == Map.СherrySymbol)
        {
            _position = targetPosition;
            _map[targetPosition.X, targetPosition.Y] = Map.EmptySymbol;
            _score += 100;
            ScoreChanged.Invoke(_score);
        }
    }

    private bool IsInsideMap(Vector2i position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < _map.Size && position.Y < _map.Size;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_position.Y, _position.X);
        Console.Write(Map.PlayerSymbol);
    }
}
