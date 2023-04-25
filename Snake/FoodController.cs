using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodController
    {
        private List<Food> _food;
        private FoodView _foodView;
        private Snake _s;
        private Field _f;

        private Random _random = new Random();

        public SizeF ContainerSize
        {
            get => _foodView.ContainerSize;
            set => _foodView.ContainerSize = value;
        }

        public FoodController(SizeF containerSize, Field f, Snake s)
        {
            _food = new List<Food>();
            _s = s;
            _f = f;
            _foodView = new FoodView(containerSize, f, _food);
            CookNew();
        }

        public void Paint(Graphics g) => _foodView.Paint(g);

        public bool TryEat()
        {
            if (_s.HeadRow == _food[0].Row
                && _s.HeadCol == _food[0].Col)
            {
                _food.Clear(); //
                CookNew();
                return true;
            }
            return false;
        }

        private void CookNew()
        {
            int row = 0;
            int col = 0;
            do
            {
                row = _random.Next(_f.RowCount);
                col = _random.Next(_f.ColumnCount);
            } while (_s.Contains(row, col));

            _food.Add(new Food() { Row = row, Col = col });
        }
    }
}
