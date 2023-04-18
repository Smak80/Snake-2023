using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameController
    {
        private FieldController _fieldController;
        private SnakeController _snakeController;

        public GameController(SizeF containerSize)
        {
            _fieldController = new FieldController(containerSize);
            _snakeController = new SnakeController(containerSize, _fieldController.F);
        }

        public void PaintScene(Graphics g)
        {
            var bg = BufferedGraphicsManager.Current.Allocate(
                g,
                Rectangle.Round(g.VisibleClipBounds)
            );
            _fieldController.Paint(bg.Graphics);
            _snakeController.Paint(bg.Graphics);
            bg.Render();
        }

        public bool NextStep()
        {
            return _snakeController.Move();
        }

        public void TurnSnake(Direction way)
        {
            _snakeController.Turn(way);
        }
    }
}
