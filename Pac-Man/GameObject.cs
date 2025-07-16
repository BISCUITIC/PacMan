using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man;

internal abstract class GameObject
{
    protected Vector2i _position;

    protected GameObject(Vector2i position){ _position = position; }         
}
