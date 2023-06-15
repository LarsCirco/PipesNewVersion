using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesNewVersion
{
    internal class Pipe
    {
        private PipeType _pipeType;
        private const string Characters = "┃━╯╰╮╭";

        public Pipe(PipeType pipeType)
        {
            _pipeType = pipeType;
        }

        public void Turn()
        {
            _pipeType = _pipeType == PipeType.DownAndLeft ? PipeType.Vertical : _pipeType + 1;
        }

        public void Write()
        {
            Console.Write(Characters[(int)_pipeType] + "   ");
        }
    }
}
