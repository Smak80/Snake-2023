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
        private bool shouldGrow = false;
        public bool IsAlive { get; private set; } = true;
        public List<SnakePart> Parts => new List<SnakePart>(SnakePart._parts);
        public Field F => _f;
        public int Length => Parts.Sum(p => p.Length);
            public int HeadRow => Parts[0].StartRow;
        public int HeadCol => Parts[0].StartCol;
        
        public Snake(Field f)
        {
            _f = f;
            SnakePart prt = new SnakePart();
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
                snakePart.Move(shouldGrow);
            }
            shouldGrow = false;
            IsAlive = HeadRow >= 0 
                   && HeadRow <  _f.RowCount 
                   && HeadCol >= 0 
                   && HeadCol <  _f.ColumnCount
                   && !Contains(HeadRow, HeadCol, false);
            if (!IsAlive) Parts[Parts.Count - 1].Length++;
            return IsAlive;
        }

        public void Turn(Direction way)
        {
            if (IsValidTurn(way))
            {
                SnakePart._parts.Insert(0, new SnakePart()
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
            if (SnakePart._parts[0].Length == 0) SnakePart._parts.RemoveAt(0);
            var currentWay = SnakePart._parts[0].Way;
            if (currentWay == way) return false;
            var res = !((currentWay == Direction.Left && way == Direction.Right)
              || (currentWay == Direction.Right && way == Direction.Left)
              || (currentWay == Direction.Top && way == Direction.Bottom)
              || (currentWay == Direction.Bottom && way == Direction.Top));
            return res;
        }

        public bool Contains(int row, int col, bool includeHead = true)
        {
            var head = true;
            foreach (var snakePart in Parts)
            {
                for (int i = 0; i < snakePart.Length; i++)
                {
                    if (head && i == 0 && !includeHead)
                    {
                        head = false;
                        continue;
                    } 
                    switch (snakePart.Way)
                    {
                        case Direction.Left:
                        {
                            if (row == snakePart.StartRow && col == snakePart.StartCol + i) return true;
                            break;
                        }
                        case Direction.Right:
                        {
                            if (row == snakePart.StartRow && col == snakePart.StartCol - i) return true;
                            break;
                        }
                        case Direction.Top:
                        {
                            if (row == snakePart.StartRow + i && col == snakePart.StartCol) return true;
                            break;
                        }
                        case Direction.Bottom:
                        {
                            if (row == snakePart.StartRow - i && col == snakePart.StartCol) return true;
                            break;
                        }
                    }
                }   
            }
            return false;
        }

        public void Grow()
        {
            shouldGrow = true;
        }
    }

    public class SnakePart
    {
        private int startRow;
        private int startCol;
        private int length = 1;
        private Direction _way;
        internal static List<SnakePart> _parts = new();
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

        public void Move(bool shouldGrow)
        {
            var partIndex = _parts.FindIndex((prt) => prt == this);
            if (partIndex == 0)
            {
                switch (Way)
                {
                    case Direction.Left:
                    {
                        startCol--;
                        break;
                    }
                    case Direction.Right:
                    {
                        startCol++;
                        break;
                    }
                    case Direction.Top:
                    {
                        startRow--;
                        break;
                    }
                    default:
                    {
                        startRow++;
                        break;
                    }
                }
                if (_parts.Count > 1) length++;
            }
            if (partIndex == _parts.Count - 1 && shouldGrow) length++;
            
            if (partIndex != 0 && partIndex == _parts.Count - 1)
            {
                length--;
                if (length == 0) _parts.Remove(this);
            }
        }
    }

    public enum Direction
    {
        Left, Right, Top, Bottom
    }
}
