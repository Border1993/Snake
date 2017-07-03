using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakePiece : GameObject
    {
        public SnakePiece(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.symbol = '#';
        }
    }
}
