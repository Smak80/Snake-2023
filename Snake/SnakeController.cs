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

        public SizeF ContainerSize
        {
            get => snakeView.ContainerSize;
            set => snakeView.ContainerSize = value;
        }

        public Snake Snake
        {
            get => snake;
        }

        public SnakeController(SizeF containerSize, Field f)
        {
            snake = new Snake(f);
            snakeView = new SnakeView(containerSize, snake);
        }

        public void Paint(Graphics g)
        {
            snakeView.Paint(g);
        }

        public bool Move() => snake.Move();

        public void Turn(Direction way)
        {
            snake.Turn(way);
        }

        public void GrowSnake() => snake.Grow();
    }
}
