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
        private Random _random = new Random();

        public FoodController(SizeF containerSize, Field f, Snake s)
        {
            _food = new List<Food>();
            _s = s;
            _foodView = new FoodView(containerSize, f, _food);
            int row = 0;
            int col = 0;
            do
            {
                row = _random.Next(f.RowCount);
                col = _random.Next(f.ColumnCount);
            } while (s.Contains(row, col));

            _food.Add(new Food() { Row = row, Col = col });

        }
    }
}
