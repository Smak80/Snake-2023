using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeView : GameView
    {
        private Snake _s;
        
        public SnakeView(SizeF containerSize, Snake s) : base(containerSize, s.F)
        {
            _s = s;
        }

        private RectangleF GetTonguePosition(int row, int col, Direction way)
        {
            var cellRect = GetCellRect(row, col);
            RectangleF tongueR;
            switch (way)
            {
                case Direction.Left:
                {
                    tongueR = new RectangleF(
                        cellRect.X, cellRect.Y + cellRect.Height / 2 - 1,
                        6, 0
                    );
                    break;
                }
                case Direction.Right:
                {
                    tongueR = new RectangleF(
                        cellRect.X + cellRect.Width - 6, 
                        cellRect.Y + cellRect.Height / 2 - 1,
                        6, 0
                    );
                    break;
                }
                case Direction.Top:
                {
                    tongueR = new RectangleF(
                        cellRect.X + cellRect.Width / 2, 
                        cellRect.Y,
                        0, 6
                    );
                    break;
                }
                default:
                {
                    tongueR = new RectangleF(
                        cellRect.X + cellRect.Width / 2,
                        cellRect.Y + cellRect.Height - 6,
                        0, 6
                    );
                    break;
                }
            }
            return tongueR;
        }

        public void Paint(Graphics g)
        {
            Brush sb = new SolidBrush(_s.IsAlive ? Color.DarkGoldenrod: Color.DarkBlue);
            Pen sp = new Pen(_s.IsAlive ? Color.SaddleBrown: Color.White, 2);
            Pen tp = new Pen(_s.IsAlive ? Color.Red: Color.LightSeaGreen, 2);
            bool head = true;
            foreach (var snakePart in _s.Parts)
            {
                for (int i = 0; i < snakePart.Length; i++)
                {
                    int row = -1, col = -1;
                    switch (snakePart.Way)
                    {
                        case Direction.Left:
                        {
                            row = snakePart.StartRow;
                            col = snakePart.StartCol + i;
                            break;
                        }
                        case Direction.Right:
                        {
                            row = snakePart.StartRow;
                            col = snakePart.StartCol - i;
                            break;
                        }
                        case Direction.Top:
                        {
                            row = snakePart.StartRow + i;
                            col = snakePart.StartCol;
                            break;
                        }
                        case Direction.Bottom:
                        {
                            row = snakePart.StartRow - i;
                            col = snakePart.StartCol;
                            break;
                        }
                    }

                    if (row >= 0 && col >= 0 && row < _s.F.RowCount && col < _s.F.ColumnCount)
                    {
                        var rect6 = GetCellRect(row, col, 6);
                        g.FillEllipse(sb, rect6);
                        g.DrawEllipse(sp, rect6);
                        if (!_s.IsAlive)
                        {
                            g.DrawLine(tp, rect6.X, rect6.Y, rect6.X+rect6.Width, rect6.Y+rect6.Height);
                            g.DrawLine(tp, rect6.X, rect6.Y + rect6.Height, rect6.X + rect6.Width, rect6.Y);
                        }
                        if (head)
                        {
                            head = false;
                            var tr = GetTonguePosition(row, col, snakePart.Way);
                            g.DrawLine(
                                tp, tr.X, tr.Y, tr.X + tr.Width, tr.Y + tr.Height
                            );
                        }
                    }
                }
            }
        }
    }
}
