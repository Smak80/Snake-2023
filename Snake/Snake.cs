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
        private Random rnd = new ();
        public List<SnakePart> Parts => new List<SnakePart>(SnakePart._parts);
        public Field F => _f;
        public Snake(Field f)
        {
            _f = f;
            SnakePart prt = new SnakePart(_f);
            prt.Length = 3;
            prt.StartRow = rnd.Next (4, _f.RowCount - 5);
            prt.StartCol = rnd.Next(4, _f.ColumnCount - 5);
            prt.Way = (Direction)rnd.Next(4);
            SnakePart._parts.Add(prt);
        }

        public bool Move()
        {
            foreach (var snakePart in Parts)
            {
                var res = snakePart.Move();
                if (res == false) return false;
            }
            return true;
        }

        public void Turn(Direction way)
        {
            if (IsValidTurn(way))
            {
                SnakePart._parts.Insert(0, new SnakePart(_f)
                {
                    Length = 0,
                    StartCol = Parts[0].StartCol,
                    StartRow = Parts[0].StartRow,
                    Way = way
                });
            }
        }

        private bool IsValidTurn(Direction way)
        {
            var currentWay = (Parts[0].Length > 0) ? Parts[0].Way : Parts[1].Way;
            if (currentWay == way) return false;
            return !((currentWay == Direction.Left && way == Direction.Right)
              || (currentWay == Direction.Right && way == Direction.Left)
              || (currentWay == Direction.Top && way == Direction.Bottom)
              || (currentWay == Direction.Bottom && way == Direction.Top));
        }
    }

    public class SnakePart
    {
        private int startRow;
        private int startCol;
        private int length = 1;
        private Direction _way;
        private Field _f;
        internal static List<SnakePart> _parts = new();
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
            var partIndex = _parts.FindIndex((prt) => prt == this);
            switch (Way)
            {
                case Direction.Left:
                {
                    if (partIndex == 0)
                    {
                        if (startCol == 0) return false;
                        startCol--;
                    }
                    break;
                }
                case Direction.Right:
                {
                    if (partIndex == 0)
                    {
                        if (startCol == _f.ColumnCount - 1) return false;
                        startCol++;
                    }
                    break;
                }
                case Direction.Top:
                {
                    if (partIndex == 0)
                    {
                        if (startRow == 0) return false;
                        startRow--;
                    }
                    break;
                }
                default:
                {
                    if (partIndex == 0)
                    {
                        if (startRow == _f.RowCount - 1) return false;
                        startRow++;
                    }
                    break;
                }
            }
            if (partIndex == 0 && _parts.Count > 1)
            {
                length++;
            }
            if (partIndex != 0 && partIndex == _parts.Count - 1)
            {
                length--;
                if (length == 0) _parts.Remove(this);
            }
            return true;
        }
    }

    public enum Direction
    {
        Left, Right, Top, Bottom
    }
}
