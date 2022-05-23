using System;

namespace Algorithm
{
    class Program
    {                
        static void Main(string[] args)
        {

            Board board = new Board();
            board.Initialize(25);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 60;
            

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

                //렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();
                
            }
        }
    }
}
