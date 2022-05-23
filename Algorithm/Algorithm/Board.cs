using System;
namespace Algorithm
{
    public class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile;
        public int _size;

        Player _player;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;
            _tile = new TileType[size, size];
            _size = size;

            _player = player;

            //Maze for Programmers

            GenerateByBinaryTree();
            GenerateBySideWinder();

        }

        private void GenerateBySideWinder()
        {

            {
                //일단 길을 다 막아버리는 작업
                for (int y = 0; y < _size; y++)
                {
                    for (int x = 0; x < _size; x++)
                    {
                        if (x % 2 == 0 || y % 2 == 0)
                            _tile[y, x] = TileType.Wall;
                        else
                            _tile[y, x] = TileType.Empty;

                    }
                }

                //랜덤으로 우측 혹은 아래로 길을 뚫는 작업

                Random rand = new Random();
                for (int y = 0; y < _size; y++)
                {
                    int count = 1;
                    for (int x = 0; x < _size; x++)
                    {
                        if (x % 2 == 0 || y % 2 == 0)
                            continue;

                        //
                        if (y == _size - 2 && x == _size - 2)
                            continue;

                        if (y == _size - 2)
                        {
                            _tile[y, x + 1] = TileType.Empty;
                            continue;
                        }

                        if (x == _size - 2)
                        {
                            _tile[y + 1, x] = TileType.Empty;
                            continue;
                        }
                        //
                        if (rand.Next(0, 2) == 0)
                        {
                            _tile[y, x + 1] = TileType.Empty;
                            count++;
                        }
                        else
                        {
                            int randomIndex = rand.Next(0, count);
                            _tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                            count = 1;
                        }
                    }
                }
            }
        }

        private void GenerateByBinaryTree()
        {
            //일단 길을 다 막아버리는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;

                }
            }

            //랜덤으로 우측 혹은 아래로 길을 뚫는 작업
           
            Random rand = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == _size - 2 && x == _size - 2)
                        continue;

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        _tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    //플레이어 좌표를 갖고와서, 그좌표랑 현재 y,x가 일치하면 플레이어 전용상으로 표시

                    if (y == _player.PosY && x == _player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = GetTileColor(_tile[y, x]);
                                    
                    Console.Write(CIRCLE);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }    
        }

    }
}
