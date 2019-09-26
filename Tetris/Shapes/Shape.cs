using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tetris.DataTypes;

namespace Tetris.Shapes
{
    /// <summary>
    /// A shape has an array of pixels (can potentially be > 4) and is identified by a code
    /// </summary>
    public abstract class Shape
    {
        public abstract char Code { get; }

        public abstract Pixel[] Pixels { get; }

        public Pixel[] LowestPixels { get; }

        public Shape()
        {
            LowestPixels = GetLowestPixels();
        }

        /// <summary>
        /// Returns the lowest pixels of each column
        /// </summary>
        /// <returns></returns>
        private Pixel[] GetLowestPixels()
        {
            if (null == Pixels)
                return null;

            var res =
                from pixel in Pixels
                group pixel by pixel.X into pixelGroup
                select new Pixel(pixelGroup.Key, pixelGroup.Min(x => x.Y));

            return res.ToArray();
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
