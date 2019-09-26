using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Services;
using Tetris.Shapes;

namespace Tetris.Services
{
    /// <summary>
    /// Service that starts games and
    /// </summary>
    public interface IGameManagerService
    {
        /// <summary>
        /// Starts a game
        /// </summary>
        /// <param name="lines">lines to process</param>
        /// <returns>array of results</returns>
        int[] StartAll(string[] lines);
    }

    public class GameManagerService : IGameManagerService
    {
        private readonly IServiceScopeFactory _servicescopefactory;
        private readonly ILogger<GameManagerService> _logger;

        public GameManagerService(IServiceScopeFactory servicescopefactory, ILogger<GameManagerService> logger)
        {
            _servicescopefactory = servicescopefactory;
            _logger = logger;
        }

        public int[] StartAll(string[] lines)
        {
            var results = new List<int>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                using (var scope = _servicescopefactory.CreateScope())
                {
                    var game = scope.ServiceProvider.GetService<IGameService>();

                    game.Start(line);
                    var result = game.GetResult();

                    results.Add(result);
                }
            }

            return results.ToArray();
        }
    }
}
