using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeController
    {
        private Snake snake;
        private SnakeView snakeView;

        public Graphics MainGraphics
        {
            get => snakeView.MainGraphics; set => snakeView.MainGraphics = value;
        }
        public SnakeController(Field f, Graphics g)
        {
            snake = new Snake(f);
            snakeView = new SnakeView(snake, g);
        }



        public void Paint()
        {
            snakeView.Paint();
        }

        public bool Move() => snake.Move();
        
    }
}
