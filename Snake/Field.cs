using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum CellState
    {
        Empty, SnakePart, Food
    }
    public class Field
    {
        // TODO: Проверить задаваемые значения
        public int RowCount { get; set; } = 20;
        public int ColumnCount { get; set; } = 10;

        private CellState[,] _cells;
        public CellState[,] Cells => _cells;

        public Field()
        {
            _cells = new CellState[RowCount, ColumnCount];
        }
    }
}
