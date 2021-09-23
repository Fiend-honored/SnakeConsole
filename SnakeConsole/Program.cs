using System;
using System.Threading;
using System.Timers;

namespace SnakeConsole
{
    class Program
    {
        private static ConsoleKey _autoDirectionMove = ConsoleKey.LeftArrow;

        const int TIMER_INTERVAL = 800;
        static System.Timers.Timer timer;
        private static Object _lockObject = new Object();

        static Snake snake = new Snake(GameField.WIDTH / 2, GameField.HEIGHT / 2, '*');

        static void Main(string[] args)
        {
            Console.SetWindowSize(GameField.WIDTH, GameField.HEIGHT);
            Console.SetBufferSize(GameField.WIDTH, GameField.HEIGHT);
            GameField.ClosedCicrleField();
            // FruitGenerator.GetPositionFruit();

            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {                    
                    var pressKey = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    MoveSnake(snake, pressKey.Key);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static void MoveSnake(Snake snake, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    snake.MoveSnake(Direction.UP);
                    _autoDirectionMove = ConsoleKey.UpArrow;
                    break;
                case ConsoleKey.LeftArrow:
                    snake.MoveSnake(Direction.LEFT);
                    _autoDirectionMove = ConsoleKey.LeftArrow;
                    break;
                case ConsoleKey.RightArrow:
                    snake.MoveSnake(Direction.RIGHT);
                    _autoDirectionMove = ConsoleKey.RightArrow;
                    break;
                case ConsoleKey.DownArrow:
                    snake.MoveSnake(Direction.DOWN);
                    _autoDirectionMove = ConsoleKey.DownArrow;
                    break;
                default:
                    break;
            }
        }
        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            MoveSnake(snake, _autoDirectionMove);
            Monitor.Exit(_lockObject);
        }

        // TODO: Отображение счета и времени игры
        // TODO: Уровни сложности
        // TODO: Меню
        // TODO: Таблица рекордов

    }
}

