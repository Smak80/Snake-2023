using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FieldView : GameView
    {
        public FieldView(Field f, Graphics g) : base(g, f) { }

        public void Paint()
        {
            MainGraphics.Clear(Color.White);
            Brush emptyCellBrush = new SolidBrush(Color.Teal);
            Pen borderPen = new Pen(Color.Black);
            for (int i = 0; i < _f.RowCount; i++)
            {
                for (int j = 0; j < _f.ColumnCount; j++)
                {
                    MainGraphics.FillRectangle(emptyCellBrush, GetCellRect(i, j));
                    MainGraphics.DrawRectangle(borderPen, GetCellRect(i, j));
                }
            }
        }
    }
}
