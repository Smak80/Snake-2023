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
        
        public SnakeView(Snake s, Graphics g) : base(g, s.F)
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
                        cellRect.X + cellRect.Width - 4, 
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
                        cellRect.Y + cellRect.Height - 4,
                        0, 6
                    );
                    break;
                }
            }
            return tongueR;
        }

        public void Paint()
        {
            Brush sb = new SolidBrush(Color.DarkGoldenrod);
            Pen sp = new Pen(Color.SaddleBrown, 2);
            Pen tp = new Pen(Color.Red, 2);
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
                    MainGraphics.FillEllipse(sb, GetCellRect(row, col, 6));
                    MainGraphics.DrawEllipse(sp, GetCellRect(row, col, 6));
                    if (head)
                    {
                        head = false;
                        var tr = GetTonguePosition(row, col, snakePart.Way);
                        MainGraphics.DrawLine(
                            tp, tr.X, tr.Y, tr.X + tr.Width, tr.Y + tr.Height
                        );
                    }
                }
            }
        }
    }
}
