using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class TetrisTest
    {
        public int BoardNbColumns { get; private set; }
        public string Input { get; private set; }
        public int ExpectedResult { get; private set; }

        public TetrisTest(int boardNbColumns, string input, int result)
        {
            BoardNbColumns = boardNbColumns;
            Input = input;
            ExpectedResult = result;
        }
    }
}
