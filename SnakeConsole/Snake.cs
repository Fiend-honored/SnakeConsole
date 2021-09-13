using System;

namespace SnakeConsole
{
    class Snake
    {
        static int _lengthSnake = 4;

        Point[] points = new Point[_lengthSnake];

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
        }

        public void MoveSnake(Direction dir)

        {
            Hide();
            var clone = Clone();            
            points[0].MovePoint(dir);
            for (int i = 1; i < _lengthSnake; i++)
            {
                points[i] = clone[i - 1];
            }
            Draw();
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
