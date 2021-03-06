using System;

namespace SnakeConsole
{
    class Snake
    {
        static int _lengthSnake = 4;
        const int START_LENGTH_SNAKE = 4;

        public static Point[] points = new Point[_lengthSnake];       

        public Snake(int x, int y, char c)
        {
            GetLengthSnake(x, y, c);
        }

        private void GetLengthSnake(int x, int y, char c)
        {
            for (int i = 0; i < _lengthSnake; i++)
            {
                points[i] = new Point(x + i, y, c);
            }
            Draw();
            // Here i`m running mechanism of appearance a fruit.
            if (_lengthSnake == START_LENGTH_SNAKE)
                FruitGenerator.GetPositionFruit();
        }

        public void MoveSnake(Direction dir)
        {
            if (CheckSnakeStrike(dir))
            {
                Hide();
                var clone = Clone();
                points[0].MovePoint(dir);
                if (points[0].X == FruitGenerator.X && points[0].Y == FruitGenerator.Y)
                {
                    GrowthSnake();
                }

                for (int i = 1; i < _lengthSnake; i++)
                {
                    points[i] = clone[i - 1];
                }
                Draw();
            }
        }
        private void GrowthSnake()
        {
            _lengthSnake++;

            var pointsCopy = new Point[_lengthSnake];
            pointsCopy[0] = new Point(points[0]);
            for(int i = 1; i < _lengthSnake; i++)
            {
                pointsCopy[i] = new Point(points[i - 1]);
            }

            points = new Point[_lengthSnake];
            for(int i = 0; i < _lengthSnake; i++)
            {
                points[i] = pointsCopy[i];
            }

            FruitGenerator.GetPositionFruit();
        }

        private bool CheckSnakeStrike(Direction dir)
        {
            var clonePoint = new Point[1];
            clonePoint[0] = new Point(points[0]);              
            foreach (var p in clonePoint)
            {
                p.MovePoint(dir);
                if (p.X == 0 || p.Y == 0 || p.X == GameField.WIDTH - 1 || p.Y == GameField.HEIGHT - 1)  // Check strike to border.               
                    GameOver();                 
                for (int i = 0; i < _lengthSnake; i++)
                {
                    if (p.X == points[i].X && p.Y == points[i].Y)  // Check strike to youself.                  
                        GameOver();                    
                }
                return true;
            } 
            return true;

        }

        private void GameOver()
        {
            while (true)
            {
                Console.SetCursorPosition(GameField.WIDTH / 2 - 8, GameField.HEIGHT / 2);
                Console.Write("G A M E   O V E R");
            }
        }

        public void Hide()
        {
            foreach (var p in points)
            {
                p.Hide();
            }
        }
        public void Draw()
        {
            foreach (var p in points)
            {
                p.Draw();
            }
        }

        public Point[] Clone()
        {
            var clonePoints = new Point[_lengthSnake];
            for (int i = 0; i < _lengthSnake; i++)
            {
                clonePoints[i] = new Point(points[i]);
            }
            return clonePoints;

        }
    }
}
