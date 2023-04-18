using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        private Field _f;
        private List<SnakePart> _parts = new();
        private Random rnd = new ();

        public List<SnakePart> Parts => new List<SnakePart>(_parts);
        public Field F => _f;
        public Snake(Field f)
        {
            _f = f;
            SnakePart prt = new SnakePart(_f);
            prt.Length = 3;
            prt.StartRow = rnd.Next (4, _f.RowCount - 5);
            prt.StartCol = rnd.Next(4, _f.ColumnCount - 5);
            prt.Way = (Direction)rnd.Next(4);
            _parts.Add(prt);
        }

        public bool Move()
        {
            foreach (var snakePart in _parts)
            {
                var res = snakePart.Move();
                if (res == false) return false;
            }
            return true;
        }

    }

    public class SnakePart
    {
        private int startRow;
        private int startCol;
        private int length = 1;
        private Direction _way;
        private Field _f;
        public SnakePart(Field f)
        {
            _f = f;
        }
        public int StartRow
        {
            get => startRow; set => startRow = value;
        }

        public int StartCol
        {
            get => startCol; set => startCol = value;
        }

        public int Length
        {
            get => length; set => length = value;
        }

        public Direction Way
        {
            get => _way; set => _way = value;
        }

        public bool Move()
        {
            switch (Way)
            {
                case Direction.Left:
                {
                    if (startCol == 0) return false;
                    startCol--;
                    break;
                }
                case Direction.Right:
                {
                    if (startCol == _f.ColumnCount - 1) return false;
                    startCol++;
                    break;
                }
                case Direction.Top:
                {
                    if (startRow == 0) return false;
                    startRow--;
                    break;
                }
                default:
                {
                    if (startRow == _f.RowCount - 1) return false;
                    startRow++;
                    break;
                }
            }

            return true;
        }
    }

    public enum Direction
    {
        Left, Right, Top, Bottom
    }
}
