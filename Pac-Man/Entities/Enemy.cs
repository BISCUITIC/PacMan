using Pac_Man.Abstractions;
using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;
using Pac_Man.UserInterface;
using System.Runtime.CompilerServices;

namespace Pac_Man.Entities;

internal class Enemy : Entity, IDrawable
{
    private readonly Player _target;   
    private Map _visitedMap;

    private Queue<(Vector2i, Vector2i)> q;
    private const char _visitedSymbol = '*';

    private Vector2i _direction;
    private bool isFound;

    public event Action CaughtUpPlayer;

    public Enemy(Vector2i startPosition, Player target) : base(startPosition)
    {
        _target = target;       
        _visitedMap = new Map();
        q = new Queue<(Vector2i, Vector2i)>();
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

        if (_visitedMap[targetPosition.X, targetPosition.Y] != _visitedSymbol &&
            _visitedMap[targetPosition.X, targetPosition.Y] != Map.WallSymbol)
        {            
            q.Enqueue((targetPosition, startDirection));
        }        
    }

    private void FindDirectionToTarget()
    {
        q = new Queue<(Vector2i, Vector2i)>();
        
        Vector2i position = _position;
        Vector2i startDirection = new Vector2i(0, 0);

        _visitedMap = new Map();
        isFound = false;

        _visitedMap[position.X, position.Y] = _visitedSymbol;

        CheckCollisions(position, (0,  1), (0,  1));
        CheckCollisions(position, (0, -1), (0, -1));
        CheckCollisions(position, (1,  0), (1,  0));
        CheckCollisions(position, (-1, 0), (-1, 0));   
        
        if(isFound) CaughtUpPlayer.Invoke();

        while (q.Count > 0 && !isFound)
        {
            (position, startDirection) = q.Dequeue();        
            _visitedMap[position.X, position.Y] = _visitedSymbol;

            CheckCollisions(position, (0, 1), startDirection);
            CheckCollisions(position, (0, -1), startDirection);
            CheckCollisions(position, (1, 0), startDirection);
            CheckCollisions(position, (-1, 0), startDirection);
        }

        _direction = startDirection;
    }

    public void Draw()
    {
        Console.SetCursorPosition(_position.Y, _position.X);
        Console.Write(Map.EnemySymbol);
    }
}
