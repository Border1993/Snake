using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point : GameObject
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.symbol = '*';
            randomGenerator = new Random();
        }

        public void Randomize(ICollidable snake)
        {
            List<Pt> points = new List<Pt>();
            for(int i = 0; i < 27 * 80; i++)
            {
                if(!snake.IsColliding(i % 80, i / 80))
                {
                    points.Add(new Pt(i % 80, i / 80));
                }
            }

            int index = randomGenerator.Next(0, points.Count);

            this.x = points[index].x;
            this.y = points[index].y;
        }

        private Random randomGenerator;
    }
}
