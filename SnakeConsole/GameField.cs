using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeConsole
{
    class GameField
    {
        public const int WIDTH = 40;
        public const int HEIGHT = 30;

        public static void ClosedCicrleField()
        {
            for(int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                    if (i == HEIGHT - 1 || j == WIDTH - 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }                        
                }      
              
            }
        }
    }
}
