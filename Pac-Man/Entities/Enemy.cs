using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;
using Pac_Man.UserInterface;
using System.Runtime.CompilerServices;

namespace Pac_Man.Entities;

internal class Enemy : Entity
{
    private readonly Player _target;   
    private Map _searchMap;

    private Queue<(Vector2i, Vector2i)> q;
    private const char _visitedSymbol = '*';

    private Vector2i _direction;
    private bool isFound;

    public event Action CaughtUpPlayer;

    public Enemy(Vector2i startPosition, Player target) : base(startPosition)
    {
        _target = target;       
        _searchMap = new Map();
        q = new Queue<(Vector2i, Vector2i)>();
    }

    public Enemy(Vector2i startPosition, Player target, Action action) : base(startPosition)
    {
        _target = target;
        _searchMap = new Map();
        q = new Queue<(Vector2i, Vector2i)>();
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

        if (targetPosition.X == _target.Position.X && targetPosition.Y == _target.Position.Y) { isFound = true; return; }

        if (_searchMap[targetPosition.X, targetPosition.Y] != _visitedSymbol &&
            _searchMap[targetPosition.X, targetPosition.Y] != Map.WallSymbol)
        {            
            q.Enqueue((targetPosition, startDirection));
        }        
    }

    private void FindDirectionToTarget()
    {
        q = new Queue<(Vector2i, Vector2i)>();
        
        Vector2i position = _position;
        Vector2i startDirection = Vector2i.Zero;

        _searchMap = new Map();
        isFound = false;

        _searchMap[position.X, position.Y] = _visitedSymbol;

        CheckCollisions(position, (0,  1), (0,  1));
        CheckCollisions(position, (0, -1), (0, -1));
        CheckCollisions(position, (1,  0), (1,  0));
        CheckCollisions(position, (-1, 0), (-1, 0));   
        
        if(isFound) CaughtUpPlayer.Invoke();

        while (q.Count > 0 && !isFound)
        {
            (position, startDirection) = q.Dequeue();        
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
