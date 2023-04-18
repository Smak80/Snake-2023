using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodView : GameView
    {
        private List<Food> _food;

        public FoodView(SizeF containerSize, Field f, List<Food> food) : base(containerSize, f)
        {
            _food = food;
        }

        public void Paint(Graphics g)
        {
            Brush fb = new SolidBrush(Color.Chartreuse);
            Pen fp = new Pen(Color.Aqua, 2);
            foreach (var food in _food)
            {
                var rect = GetCellRect(food.Row, food.Col, 6);
                g.FillEllipse(fb, rect);
                g.DrawEllipse(fp, rect);
            }
        }
    }
}
