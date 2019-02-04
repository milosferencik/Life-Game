using System;

namespace LiveGame
{
    class MainClass
    {
        private static int LiveNeighbour(int[,] world, int i, int j, int size)
        {
            int result = 0;
            for (int x = Math.Max(0, i - 1); x <= Math.Min(i + 1, size - 1); x++)
            {
                for (int y = Math.Max(0, j - 1); y <= Math.Min(j + 1, size - 1); y++)
                {
                    if (x != i || y != j)
                    {
                        result += world[x, y];
                    }
                }
            }
            return result;
        }

        private static int[,] Run(int[,] newWorld, int[,] oldWorld, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int liveNeighbour = LiveNeighbour(oldWorld, i, j, size);

                    if (liveNeighbour < 2 || liveNeighbour > 3)
                    {
                        newWorld[i, j] = 0;
                    }
                    else if (liveNeighbour == 3)
                    {
                        newWorld[i, j] = 1;
                    }
                    else
                    {
                        newWorld[i, j] = oldWorld[i, j];
                    }
                }
            }
            return newWorld;
        }

        private static void Print(int[,] world, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(world[i, j]);
                }
                Console.Write("\n");
            }
        }

        private static int[,] InitializeWorld(int size)
        {
            Random random = new Random();

            int[,] array = new int[size, size];

            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    array[i, j] = random.Next() % 2;
            return array;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of game world!");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] world1;
            int[,] world2;
            world1 = world2 = InitializeWorld(size);
            int iterator = 1;
            Console.WriteLine("Initial world");
            Print(world2, size);
            while (true)
            {

                Console.WriteLine($"Round {iterator}.");
                if (iterator % 2 == 1)
                {
                    world1 = Run(world1, world2, size);
                    Print(world1, size);
                }
                else
                {
                    world2 = Run(world2, world1, size);
                    Print(world2, size);
                }
                iterator++;
                Console.WriteLine("Press 'q' to end! \nPress something else to continue!");
                if (Console.ReadKey().KeyChar.Equals('q')) return;
            }
        }
    }
}
