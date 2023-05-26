using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FieldView : GameView
    {
        public FieldView(SizeF containerSize, Field f) : base(containerSize, f) { }

        public void Paint(Graphics g)
        {
            g.Clear(Color.White);
            Brush emptyCellBrush = new SolidBrush(Color.Teal);
            Pen borderPen = new Pen(Color.Black);
            for (int i = 0; i < _f.RowCount; i++)
            {
                for (int j = 0; j < _f.ColumnCount; j++)
                {
                    g.FillRectangle(emptyCellBrush, GetCellRect(i, j));
                    g.DrawRectangle(borderPen, Rectangle.Round(GetCellRect(i, j)));
                }
            }
        }
    }
}
