using Pac_Man.CoordinatesSystem;
using Pac_Man.Interfaces;

namespace Pac_Man.Abstractions;

internal abstract class InterfaceObject : IDrawable
{
    protected Vector2i _diplayPosition;

    protected InterfaceObject(Vector2i position) { _diplayPosition = position; }

    public virtual void Draw() { }
}
