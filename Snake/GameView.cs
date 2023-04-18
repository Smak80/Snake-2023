using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class GameView
    {
        private Graphics _g;
        protected Field _f;
        public Graphics MainGraphics
        {
            get => _g; set => _g = value;
        }

        public GameView(Graphics g, Field f)
        {
            MainGraphics = g;
            _f = f;
        }

        protected float CellSize
        {
            get
            {
                var maxCellWidth = MainGraphics.VisibleClipBounds.Width / _f.ColumnCount;
                var maxCellHeight = MainGraphics.VisibleClipBounds.Height / _f.RowCount;
                return Math.Min(maxCellWidth, maxCellHeight);
            }
        }
        protected RectangleF MainRect
        {
            get
            {
                var w = MainGraphics.VisibleClipBounds.Width - CellSize * _f.ColumnCount;
                var h = MainGraphics.VisibleClipBounds.Height - CellSize * _f.RowCount;
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
