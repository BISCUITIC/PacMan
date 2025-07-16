using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man;

internal abstract class InterfaceObject:IDrawable
{
    protected Vector2i _diplayPosition;

    protected InterfaceObject(Vector2i position) { _diplayPosition = position; }
    
    public virtual void Draw() { }
}
