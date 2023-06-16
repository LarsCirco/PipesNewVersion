using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesNewVersion
{
    internal class Board
    {
        private Random random = new Random();
        public List<Pipe> Pipes { get; set; } = new List<Pipe>();
        private int coll;
        private int Peker = 0;

        public Board(int Row,int Coll)
        {
            coll = Coll;
            RenderBoard(Row);
            DrawBoard();
        }

        public void RenderBoard(int Row)
        {
            var size = Row * coll;
            for (var i = 0; i < size; i++)
            {
                Pipes.Add(RandomPipe());
            }
        }

        public void DrawBoard()
        {
            Console.Clear();
            int count = 0;


            foreach (var pipe in Pipes)
            {
                if (count % coll == 0)
                {
                    Console.WriteLine();
                }

                if (count == Peker)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ResetColor();
                }

                pipe.Write();
                count++;
            }
            Console.ResetColor();
            if (count % coll == 0)
            {
                Console.WriteLine(" ");

            }

        }
        private Pipe RandomPipe()
        { 
            var randomPipeType = (PipeType)random.Next(0, 6);
            return new Pipe(randomPipeType);

        }

        public void userinput()
        {
            var UserInput = Console.ReadKey(true);

            switch (UserInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Peker - coll >= 0)
                    {
                        Peker -= coll;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (Peker + coll < Pipes.Count)
                    {
                        Peker += coll;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (Peker > 0)
                    {
                        Peker--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (Peker < Pipes.Count - 1)
                    {
                        Peker++;
                    }
                    break;

                case ConsoleKey.Spacebar:
                    Pipes[Peker].Turn();
                    break;

                default:
                    break;
            }


            DrawBoard();
        }
    }
}

