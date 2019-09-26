using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tetris.Services;
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
            //setup DI
            var services = new ServiceCollection()
                .InitializeServices(BOARD_NB_COLUMNS);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                Process(serviceProvider);
            }
        }

        private static void Process(ServiceProvider serviceProvider)
        {
            var lines = File.ReadAllLines(INPUT_FN);

            var gameManager = serviceProvider.GetService<IGameManagerService>();
            var results = gameManager.StartAll(lines);

            File.WriteAllLines(OUTPUT_FN, results.Select(x => x.ToString()));
        }
    }
}
