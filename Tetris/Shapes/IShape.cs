using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Shapes
{
    public class IShape : Shape
    {
        public override char Code => 'I';

        public override Pixel[] Pixels => new Pixel[4]
        {
            new Pixel(0, 0),
            new Pixel(1, 0),
            new Pixel(2, 0),
            new Pixel(3, 0),
        };
    }
}
