using Pac_Man.CoordinatesSystem;

namespace Pac_Man.Abstractions;

internal abstract class GameObject
{
    protected Vector2i _position;

    protected GameObject(Vector2i position) { _position = position; }
}
