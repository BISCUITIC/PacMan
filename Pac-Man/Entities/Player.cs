using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;
using Pac_Man.UserInterface;

namespace Pac_Man.Entities;

internal class Player : Entity, IDrawable
{
    private readonly Map _map;
    
    private readonly PlayerMovementController _playerMovementController;

    private int _score;

    private Vector2i _direction;

    public delegate void Change(int newValue);
    public event Change ScoreChanged;

    public Vector2i Position { get => _position; }
    public Player(Map map, Vector2i startPosition) : base(startPosition)
    {
        _map = map;
        _score = 0;
        _direction = new Vector2i(0, 0);
        _playerMovementController = new PlayerMovementController();
    }

    public override void Update()
    {
        _playerMovementController.Update();
        
        _position += _direction;

        CheckCollisions();
    }

    private void CheckCollisions()
    {
        Vector2i targetPosition = _position + _playerMovementController.Direction;

        if (_map[targetPosition.X, targetPosition.Y] == Map.EmptySymbol)
        {
            _direction = _playerMovementController.Direction;
        }

        targetPosition = _position + _direction;

        if (_map[targetPosition.X, targetPosition.Y] == Map.WallSymbol)
        {
            _direction = new Vector2i(0, 0);
        }
        if (_map[targetPosition.X, targetPosition.Y] == Map.СherrySymbol)
        {            
            _map[targetPosition.X, targetPosition.Y] = Map.EmptySymbol;
            _score += 100;
            ScoreChanged.Invoke(_score);
        }

       
    }  

    public void Draw()
    {
        Console.SetCursorPosition(_position.Y, _position.X);
        Console.Write(Map.PlayerSymbol);
    }
}
