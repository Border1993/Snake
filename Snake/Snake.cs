using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : IDrawable, ICollidable
    {
        public Snake()
        {
            pieces = new List<SnakePiece>();
            pieces.Add(new SnakePiece(10, 10));
            pieces.Add(new SnakePiece(10, 11));
            pieces.Add(new SnakePiece(10, 12));
            pieces.Add(new SnakePiece(10, 13));

            isDead = false;
            this.direction = EDirection.RIGHT;
            score = 0;
        }

        public bool IsColliding(int x, int y)
        {
            foreach(SnakePiece piece in pieces)
            {
                if (piece.IsColliding(x, y)) return true;
            }
            return false;
        }

        public void Draw(char[] buffer)
        {
            try
            {
                foreach (SnakePiece piece in pieces)
                {
                    piece.Draw(buffer);
                }
            }
            catch(IndexOutOfRangeException)
            {
                isDead = false;
            }
        }

        public void ControlSnake(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow) ChangeDirection(EDirection.RIGHT);
            else if (key.Key == ConsoleKey.LeftArrow) ChangeDirection(EDirection.LEFT);
            else if (key.Key == ConsoleKey.UpArrow) ChangeDirection(EDirection.UP);
            else if (key.Key == ConsoleKey.DownArrow) ChangeDirection(EDirection.DOWN);
        }

        public void Tick(ICollidable point)
        {
            pointTaken = false;

            foreach(SnakePiece piece in pieces)
            {
                if(piece.CheckCollision(point))
                {
                    pointTaken = true;
                    score++;
                }
            }

            if(!pointTaken)
            {
                pieces.RemoveAt(0);
            }

            int newX = pieces.Last().X;
            int newY = pieces.Last().Y;

            switch (direction)
            {
                case EDirection.DOWN:
                    newY++;
                    break;

                case EDirection.UP:
                    newY--; 
                    break;

                case EDirection.LEFT:
                    newX--;
                    break;

                case EDirection.RIGHT:
                    newX++;
                    break;
            }

            pieces.Add(new SnakePiece(newX, newY));

            CheckSelfCollision();
        }

        private void ChangeDirection(EDirection direction)
        {
            if ((int)this.direction != (int)direction * -1) this.direction = direction;
        }

        public bool IsDead
        {
            get { return isDead; }
            //read only
        }

        public bool GainedPoint
        {
            get { return pointTaken; }
            //read only
        }
        
        public int Score
        {
            get { return score; }
            //read only
        }

        private void CheckSelfCollision()
        {
            SnakePiece front = pieces[0];

            for (int i = 1; i < pieces.Count; i++)
            {
                if (pieces[i].CheckCollision(front))
                {
                    isDead = true;
                }
            }
        }

        List<SnakePiece> pieces;
        EDirection direction;
        bool pointTaken;
        int score;

        bool isDead;
    }
}
