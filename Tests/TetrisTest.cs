using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class TetrisTest
    {
        public string Input { get; private set; }
        public int ExpectedResult { get; private set; }

        public TetrisTest(string input, int result)
        {
            Input = input;
            ExpectedResult = result;
        }
    }
}
