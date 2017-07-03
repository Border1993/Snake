using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Game
    {
        public Game()
        {
            snake = new Snake();
            point = new Point(15, 15);
            video = new Video();
            gameOver = false;
        }

        public void Run()
        {
            while(!gameOver) MainLoop();
        }

        private void MainLoop()
        {
            try
            {
                Control();
                snake.Tick(point);
                Logic();
                Render();
                Thread.Sleep(200);
            }
            catch(Exception ex)
            {
                gameOver = true;
                GameOverScreen(ex.Message);
            }
            
            
        }

        private void Control()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                snake.ControlSnake(key);

                while (Console.KeyAvailable) Console.ReadKey();
            }
        }

        private void Render()
        {
            video.Clear();
            video.Draw(snake);
            video.Draw(point);
            video.DrawAll();
        }

        private void Logic()
        {
            if (snake.IsDead)
            {
                gameOver = true;
                throw new Exception("Game over. Collision with yourself.");
            }

            if (snake.GainedPoint) point.Randomize(snake);
        }

        private void GameOverScreen(string str)
        {
            Console.Clear();
            Console.WriteLine(str);
            Console.WriteLine("Score = " + snake.Score);

            Thread.Sleep(5000);
        }

        Snake snake;
        Point point;
        Video video;
        bool gameOver;
    }
}
