using System;
using System.Collections.Generic;
using System.IO;
using Tetris.Shapes;

namespace Tetris
{
    class Program
    {
        private const string INPUT_FN = "input.txt";
        private const string OUTPUT_FN = "output.txt";

        // can handle more than 10 rows
        private const int BOARD_NB_COLUMNS = 10;

        static void Main(string[] args)
        {
            string line;

            using (var reader = new StreamReader(INPUT_FN))
            {
                using (var writer = File.CreateText(OUTPUT_FN))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                            continue;

                        var game = new Game(BOARD_NB_COLUMNS, line);
                        var result = game.GetResult();

                        writer.WriteLine(result);
                    }
                }
            }
        }
    }
}
