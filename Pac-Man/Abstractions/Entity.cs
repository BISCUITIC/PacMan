using Pac_Man.CoordinatesSystem;
using Pac_Man.UserInterface;
using System.Runtime.InteropServices.Marshalling;

namespace Pac_Man.Abstractions;

internal abstract class Entity : GameObject
{

    public Entity(Vector2i position) : base(position) { }    
    public abstract void Update();    
}
