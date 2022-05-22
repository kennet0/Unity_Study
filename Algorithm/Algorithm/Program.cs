using System;

namespace Algorithm
{
    class Program
    {                
        static void Main(string[] args)
        {

            Board board = new Board();
            board.Initialize();

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 60;
            const char CIRCLE = '\u25cf';

            int lastTick = 0;
            while(true)
            {
                #region 프레임 관리
                //만약에 경과한 시간이 1/30초보다 작다면
                int currentTick = System.Environment.TickCount & Int32.MaxValue;              
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;
                #endregion

                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.Write(CIRCLE);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;                  
                    Console.WriteLine();
                }
            }
        }
    }
}
