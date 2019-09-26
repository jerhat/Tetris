using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection InitializeServices(this IServiceCollection services, int nbcolumns)
        {
            return services
                .AddLogging(logging => logging.AddConsole())
                .AddSingleton<IShapeService, ShapeService>()
                .AddTransient<IBoardService, BoardService>().Configure<BoardOptions>(options => options.NbColumns = nbcolumns)
                .AddTransient<IGameService, GameService>()
                .AddSingleton<IGameManagerService, GameManagerService>();
        }
    }
}
