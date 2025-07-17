using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;
using Pac_Man.UserInterface;

namespace Pac_Man.Entities;

internal class Player : Entity
{
    private readonly Map _map;
    
    private readonly PlayerMovementController _playerMovementController;
    
    private Vector2i _direction;
    public Vector2i Position { get => _position; }

    private int _score;
    public int Score { get => _score; }

    public Player(Vector2i startPosition, Map map) : base(startPosition)
    {
        _map = map;
        _score = 0;
        _direction = Vector2i.Zero;
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
            _direction = Vector2i.Zero;
        }
        if (_map[targetPosition.X, targetPosition.Y] == Map.СherrySymbol)
        {            
            _map[targetPosition.X, targetPosition.Y] = Map.EmptySymbol;
            _score += 100;
        }       
    }  

    public override void Draw()
    {
        Console.SetCursorPosition(_position.Y, _position.X);
        Console.Write(Map.PlayerSymbol);
    }
}
