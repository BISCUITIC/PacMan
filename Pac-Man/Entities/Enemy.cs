using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;
using Pac_Man.UserInterface;
using System.Runtime.CompilerServices;

namespace Pac_Man.Entities;

internal class Enemy : Entity
{
    private readonly Player _target;       
    private Vector2i _direction;
    private Map _searchMap;
    private bool _isFound;

    private Queue<(Vector2i, Vector2i)> _queueSearch;
    private const char _visitedSymbol = '*';    

    public event Action CaughtUpPlayer;

    public Enemy(Vector2i startPosition, Player target) : base(startPosition)
    {
        _target = target;       
        _searchMap = new Map();
        _queueSearch = new Queue<(Vector2i, Vector2i)>();
    }

    public Enemy(Vector2i startPosition, Player target, Action action) : base(startPosition)
    {
        _target = target;
        _searchMap = new Map();
        _queueSearch = new Queue<(Vector2i, Vector2i)>();
        CaughtUpPlayer += action;
    }


    public override void Update()
    {
        FindDirectionToTarget();

        _position += _direction;
    }

    private void CheckCollisions(Vector2i position, Vector2i direction, Vector2i startDirection)
    {
        Vector2i targetPosition = position + direction;

        if (targetPosition.X == _target.Position.X && targetPosition.Y == _target.Position.Y) { _isFound = true; return; }

        if (_searchMap[targetPosition.X, targetPosition.Y] != _visitedSymbol &&
            _searchMap[targetPosition.X, targetPosition.Y] != Map.WallSymbol)
        {            
            _queueSearch.Enqueue((targetPosition, startDirection));
        }        
    }

    private void FindDirectionToTarget()
    {
        _queueSearch = new Queue<(Vector2i, Vector2i)>();
        
        Vector2i position = _position;
        Vector2i startDirection = Vector2i.Zero;

        _searchMap = new Map();
        _isFound = false;

        _searchMap[position.X, position.Y] = _visitedSymbol;

        CheckCollisions(position, (0,  1), (0,  1));
        CheckCollisions(position, (0, -1), (0, -1));
        CheckCollisions(position, (1,  0), (1,  0));
        CheckCollisions(position, (-1, 0), (-1, 0));   
        
        if(_isFound) CaughtUpPlayer.Invoke();

        while (_queueSearch.Count > 0 && !_isFound)
        {
            (position, startDirection) = _queueSearch.Dequeue();        
            _searchMap[position.X, position.Y] = _visitedSymbol;

            CheckCollisions(position, (0, 1), startDirection);
            CheckCollisions(position, (0, -1), startDirection);
            CheckCollisions(position, (1, 0), startDirection);
            CheckCollisions(position, (-1, 0), startDirection);
        }

        _direction = startDirection;
    }

    public override void Draw()
    {
        Console.SetCursorPosition(_position.Y, _position.X);
        Console.Write(Map.EnemySymbol);
    }
}
