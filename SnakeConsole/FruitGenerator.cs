using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeConsole
{
    class FruitGenerator
    {
        public static int X { get; set; }

        public static int Y { get; set; }

        private static Random _random = new Random();

        public static void GetPositionFruit()
        {
            CheckFruitInSnake();
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }

        private static void CheckFruitInSnake()
        {            
            while (true)
            {
                int xPositionFruit = _random.Next(1, GameField.WIDTH - 1);
                int yPositionFruit = _random.Next(1, GameField.HEIGHT - 1);
                int counter = 0;
                foreach (var p in Snake.points)
                {
                    if(p.X == xPositionFruit && p.Y == yPositionFruit)
                        counter++;
                }
                if (counter == 0)
                {
                    X = xPositionFruit;
                    Y = yPositionFruit;
                    break;
                }                                                    
            }           
        }
    }
}
