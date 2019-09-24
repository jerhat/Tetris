using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Shapes
{
    public class LShape : Shape
    {
        public override char Code => 'L';

        public override Pixel[] Pixels => new Pixel[4]
        {
            new Pixel(0, 0),
            new Pixel(0, 1),
            new Pixel(0, 2),
            new Pixel(1, 0),
        };
    }
}
