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

        private Graphics _mainG;

        public Graphics MainGraphics
        {
            get => _mainG;
            set
            {
                _mainG = value;
                _fieldController.MainGraphics = value;
                _snakeController.MainGraphics = value;
            }
        }

        public GameController(Graphics mainGraphics)
        {
            _fieldController = new FieldController(mainGraphics);
            _snakeController = new SnakeController(_fieldController.F, mainGraphics);
        }

        public void PaintScene(Graphics g)
        {
            var bg = BufferedGraphicsManager.Current.Allocate(
                g,
                Rectangle.Round(g.VisibleClipBounds)
            );
            MainGraphics = bg.Graphics;
            _fieldController.Paint();
            _snakeController.Paint();
            bg.Render();
        }

        public bool NextStep()
        {
            return _snakeController.Move();
        }
        
    }
}
