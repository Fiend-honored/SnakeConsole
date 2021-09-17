using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeConsole
{
    class FruitGenerator
    {
        public static int X { get; set; }

        public static int Y { get; set; }

        static Random random = new Random();

        public static void GetPositionFruit()
        {
            int xPositionFruit = random.Next(1, GameField.WIDTH - 1);
            X = xPositionFruit;
            int yPositionFruit = random.Next(1, GameField.HEIGHT - 1);
            Y = yPositionFruit;
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
