using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Video
    {
        public Video()
        {
            buffer = new char[28 * 80];
        }

        public void Clear()
        {
            Console.Clear();
            for(int i = 0; i < 28*80; i++)
            {
                buffer[i] = ' ';
            }
        }

        public void Draw(IDrawable obj)
        {
            obj.Draw(buffer);
        }

        public void DrawAll()
        {
            string str = new string(buffer);
            Console.Write(str);
        }

        private char[] buffer;
        
    }
}
