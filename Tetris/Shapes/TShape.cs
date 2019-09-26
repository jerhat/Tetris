using System;
using System.Collections.Generic;
using System.Text;
using Tetris.DataTypes;

namespace Tetris.Shapes
{
    public class TShape : Shape
    {
        public override char Code => 'T';

        public override Pixel[] Pixels => new Pixel[4]
        {
            new Pixel(0, 1),
            new Pixel(1, 1),
            new Pixel(1, 0),
            new Pixel(2, 1),
        };
    }
}
