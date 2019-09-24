using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Shapes;

namespace Tetris
{
    public class Game
    {
        private readonly Board _board;

        public Game(int nbColumns, string inputline)
        {
            System.Diagnostics.Debug.WriteLine($"Starting game from '{inputline}'");

            _board = new Board(nbColumns);

            ProcessLine(inputline);
        }

        private void ProcessLine(string input)
        {
            var items = input.Split(',');

            foreach (var item in items)
            {
                char code = item[0];
                var col = Convert.ToUInt16(item.Substring(1, item.Length - 1));

                var shape = ShapeProvider.GetShape(code);

                _board.Drop(shape, col);
            }
        }

        public int GetResult()
        {
            return _board.GetResult();
        }
    }
}
