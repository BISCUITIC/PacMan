using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man;

internal abstract class Entity : GameObject
{    
    protected Entity(Vector2i position):base(position) { }

    protected virtual void Move() { }
}
