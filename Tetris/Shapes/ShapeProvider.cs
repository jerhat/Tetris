using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Shapes
{
    class ShapeProvider
    {
        private static Dictionary<Char, Shape> _shapes;

        public static Shape GetShape(char code)
        {
            if (null == _shapes)
                InitCache();

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
