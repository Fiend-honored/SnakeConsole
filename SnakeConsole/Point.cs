using System;

namespace SnakeConsole
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sym { get; set; }

        public Point(int x, int y, char c)
        {
            X = x;
            Y = y;
            Sym = c;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Sym = point.Sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
            Console.SetCursorPosition(0, 0);
        }

        public void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }

        public void MovePoint(Direction dir)
        {
            switch (dir)
            {
                case Direction.DOWN:
                    Y++;
                    break;
                case Direction.LEFT:
                    X--;
                    break;
                case Direction.RIGHT:
                    X++;
                    break;
                case Direction.UP:
                    Y--;
                    break;
            }
        }
    }
}
