using System;
using System.Collections.Generic;
using System.Text;
using Tetris.DataTypes;

namespace Tetris.Shapes
{
    public class ZShape : Shape
    {
        public override char Code => 'Z';

        public override Pixel[] Pixels => new Pixel[4]
        {
            new Pixel(0, 1),
            new Pixel(1, 1),
            new Pixel(1, 0),
            new Pixel(2, 0),
        };
    }
}
