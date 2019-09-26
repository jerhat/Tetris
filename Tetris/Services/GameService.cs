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
    /// Service that can start a game and get its result
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Starts a game
        /// </summary>
        /// <param name="input">input string to process</param>
        void Start(string input);

        /// <summary>
        /// Get the result
        /// </summary>
        /// <returns>Result, i.e. the final height of the board</returns>
        int GetResult();
    }

    public class GameService : IGameService
    {
        private readonly IShapeService _shapeService;
        private readonly ILogger<GameService> _logger;
        private readonly IBoardService _boardService;

        public GameService(IShapeService shapeservice, IBoardService boardservice, ILogger<GameService> logger)
        {
            _boardService = boardservice;
            _shapeService = shapeservice;
            _logger = logger;
        }

        public void Start(string input)
        {
            _logger.LogInformation($"Starting game using '{input}'");

            var items = input.Split(',');

            foreach (var item in items)
            {
                char code = item[0];
                var col = Convert.ToUInt16(item.Substring(1, item.Length - 1));

                var shape = _shapeService.GetShape(code);

                _boardService.Drop(shape, col);
            }
        }

        /// <summary>
        /// Returns the board top most used row minus the number of full rows
        /// </summary>
        /// <returns></returns>
        public int GetResult()
        {
            return _boardService.GetTopRowNumber() - _boardService.GetNbFullRows();
        }
    }
}
