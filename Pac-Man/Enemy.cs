using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man;

internal class Enemy:Entity, IDrawable
{
    public Enemy(Vector2i startPosition):base(startPosition)
    {
        
    }

    public void Draw()
    {

    }
}
