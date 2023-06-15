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
                pipe.Write();
                count++;
                if (count % coll == 0)
                { Console.WriteLine(" "); }
            }


        }
        private Pipe RandomPipe()
        { 
            var randomPipeType = (PipeType)random.Next(0, 6);
            return new Pipe(randomPipeType);

        }

        public void userinput(string index)
        {
            int.TryParse(index, out int input);
            Pipes[input].Turn();
            DrawBoard();
        }
    }
}

