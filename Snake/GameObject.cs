using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class GameObject : ICollidable, IDrawable
    {
        public GameObject()
        {
            x = 0;
            y = 0;
            symbol = 'E';
        }

        //overload in subclasses
        public bool IsColliding(int x, int y)
        {
            if (this.x == x && this.y == y) return true;
            else return false;
        }

        public bool CheckCollision(ICollidable obj)
        {
            if (obj.IsColliding(this.x, this.y)) return true;
            else return false;
        }

        public void Draw(char[] buffer)
        {
            if (x < 0 || x >= 80 || y < 0 || y >= 28)
            {
                throw new Exception("Game over. Collided with a wall.");
            }
            buffer[x + y * 80] = symbol;
        }

        public char symbol;

        public int X
        {
            get { return x; }
            // read only
        }

        public int Y
        {
            get { return y; }
            // read only
        }

        protected int x;
        protected int y;
    }
}
