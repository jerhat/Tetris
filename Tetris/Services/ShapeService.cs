using System;
using System.Collections.Generic;
using System.Linq;
using Tetris.Shapes;

namespace Tetris.Services
{
    /// <summary>
    /// Service responsible for providing shapes
    /// </summary>
    public interface IShapeService
    {
        Shape GetShape(char code);
    }

    public class ShapeService : IShapeService
    {
        private static Dictionary<Char, Shape> _shapes;

        static ShapeService()
        {
            InitCache();
        }

        public Shape GetShape(char code)
        {
            if (!_shapes.TryGetValue(code, out var shape))
                throw new Exception($"Unknown shape code: {code}");

            return shape;
        }

        /// <summary>
        /// Initializes the dictionary of shape types through reflection (to avoid a switch)
        /// </summary>
        static void InitCache()
        {
            _shapes = new Dictionary<char, Shape>();

            foreach (var shapetype in typeof(Shape).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(Shape).IsAssignableFrom(t)))
            {
                var shape = Activator.CreateInstance(shapetype) as Shape;

                _shapes[shape.Code] = shape;
            }
        }
    }
}
