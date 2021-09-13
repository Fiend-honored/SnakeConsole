using System;

namespace SnakeConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.SetWindowSize(GameField.WIDTH, GameField.HEIGHT);
            Console.SetBufferSize(GameField.WIDTH, GameField.HEIGHT);
            GameField.ClosedCicrleField();

            Snake snake = new Snake(GameField.WIDTH / 2, GameField.HEIGHT / 2, '*');

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var pressKey = Console.ReadKey();
                    MoveSnake(snake, pressKey.Key);

                }
            }
        }

        private static void MoveSnake(Snake snake, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    snake.MoveSnake(Direction.UP);
                    break;
                case ConsoleKey.LeftArrow:
                    snake.MoveSnake(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    snake.MoveSnake(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    snake.MoveSnake(Direction.DOWN);
                    break;
                default:
                    break;
            }
        }

        // TODO: Запрет за выход границ экрана
        // TODO: Появление фрукта и увеличение длинны змеи
        // TODO: Условия проигрыша
        // TODO: Уровни

    }
}
