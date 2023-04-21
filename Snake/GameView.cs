using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class GameView
    {
        protected Field _f;
        public SizeF ContainerSize { get; set; }

        public GameView(SizeF containerSize, Field f)
        {
            //MainGraphics = g;
            ContainerSize = containerSize;
            _f = f;
        }

        protected float CellSize
        {
            get
            {
                var maxCellWidth = ContainerSize.Width / _f.ColumnCount;
                var maxCellHeight = ContainerSize.Height / _f.RowCount;
                return Math.Min(maxCellWidth, maxCellHeight);
            }
        }
        protected RectangleF MainRect
        {
            get
            {
                var w = ContainerSize.Width - CellSize * _f.ColumnCount;
                var h = ContainerSize.Height - CellSize * _f.RowCount;
                return new RectangleF(
                    w / 2, h / 2,
                    CellSize * _f.ColumnCount,
                    CellSize * _f.RowCount
                );
            }
        }
        protected RectangleF GetCellRect(int rowNum, int colNum, uint padding = 1)
        {
            return new RectangleF(
                (colNum) * CellSize + padding + MainRect.X,
                (rowNum) * CellSize + padding + MainRect.Y,
                CellSize - 2 * padding,
                CellSize - 2 * padding
            );
        }
    }
}
