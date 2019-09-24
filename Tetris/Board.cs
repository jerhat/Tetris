using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tetris.Shapes;

namespace Tetris
{
    public class Board
    {
        // Each column of the board is represented by a list of bool (true: the pixel is used ; false: the pixel is free)
        private readonly List<bool>[] _columns;

        // List of full rows
        private readonly List<int> fullRows;

        #region Public methods
        public Board(int nbColumns)
        {
            _columns = new List<bool>[nbColumns];
            for (int i = 0; i < nbColumns; i++)
            {
                _columns[i] = new List<bool>();
            }

            fullRows = new List<int>();
        }

        public void Drop(Shape shape, ushort column)
        {
            System.Diagnostics.Debug.WriteLine($"Dropping shape '{shape}' into column '{column}'");
            var landingRow = GetTargetRow(shape, column);

            System.Diagnostics.Debug.WriteLine($"Landed at row '{landingRow}'");
            AddShape(shape, column, landingRow);
        }

        /// <summary>
        /// Returns the top most used row minus the number of full rows
        /// </summary>
        /// <returns></returns>
        public int GetResult()
        {
            return GetBoardTopRow() - fullRows.Count;
        }

        /// <summary>
        /// Get string representation of the board (rotated 90 deg clockwise for simplicity)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _columns.Length; i++)
            {
                sb.AppendLine(string.Join(' ', _columns[i].Select(c => c ? 'X' : ' ')));
            }

            return sb.ToString();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Returns the target row, i.e. where to place the shape
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>The target row of the bottom-most pixels of the shape</returns>
        private ushort GetTargetRow(Shape shape, ushort column)
        {
            ushort currentRow = 0;

            while (!CanFit(shape, column, currentRow)) // we try to place the shape from bottom to top
                currentRow++;

            return currentRow;
        }

        /// <summary>
        /// Checks whether a shape can fit in the board at the specified location,
        /// i.e. no pixel are already used by another shape and the is no pixel above
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="x">X coordinate of the left-most pixel of the shape</param>
        /// <param name="y">Y coordinate of the bottom-most pixel of the shape</param>
        /// <returns>true if can fit, false otherwise</returns>
        private bool CanFit(Shape shape, ushort x, ushort y)
        {
            foreach (var pixel in shape.LowestPixels)
            {
                var targetX = x + pixel.X;
                var targetY = y + pixel.Y;

                if (!IsFree(targetX, targetY))
                    return false; // if the pixel is already used we return false

                if (GetLowestFreeRow(targetX) > targetY)
                    return false; // if there is pixel above we also return false
            }

            return true;
        }

        /// <summary>
        /// Integrates the shape into the board
        /// </summary>
        /// <param name="shape">Shape to add</param>
        /// <param name="x">X coordinate in the board</param>
        /// <param name="y">Y coordinate in the board</param>
        private void AddShape(Shape shape, ushort x, ushort y)
        {
            List<int> rowsToCheck = new List<int>();

            foreach (var pixel in shape.Pixels)
            {
                var targetX = x + pixel.X;
                var targetY = y + pixel.Y;

                var curColumn = _columns[targetX];

                while (curColumn.Count <= targetY)
                {
                    curColumn.Add(false); // if needed, fills gaps with empty pixels
                }

                curColumn[targetY] = true;

                if (!rowsToCheck.Contains(targetY))
                    rowsToCheck.Add(targetY);
            }

            // check the impacted rows for full lines
            CheckFullRows(rowsToCheck);

            // prints the resulting board 
            System.Diagnostics.Debug.WriteLine(this);
        }

        private void CheckFullRows(List<int> rows)
        {
            foreach (var row in rows)
            {
                if (_columns.All(c => c.Any() && c.Count > row && c[row]))
                {
                    System.Diagnostics.Debug.WriteLine($"Row '{row}' is filled");
                    fullRows.Add(row);
                }
            }
        }

        /// <summary>
        /// Checks whether a particular pixel in the board is free or not
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true: pixel is free; false: pixel is already used by a shape</returns>
        private bool IsFree(int x, int y)
        {
            return _columns[x].Count <= y || !_columns[x][y];
        }

        /// <summary>
        /// Returns the lowest available row for a specific board column
        /// </summary>
        /// <param name="column"></param>
        /// <returns>The lowest available row</returns>
        private int GetLowestFreeRow(int column)
        {
            return Math.Max(_columns[column].FindLastIndex(x => x) + 1, 0);
        }

        private int GetBoardTopRow()
        {
            return _columns.Select((c, i) => GetLowestFreeRow(i)).Max();
        }

        #endregion
    }
}
