using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public delegate void AteDelegate();
    public delegate void GrowDelegate(int length);


    public class GameController
    {
        private bool _shouldGrow = false;
        private FieldController _fieldController;
        private SnakeController _snakeController;
        private FoodController _foodController;

        private SizeF _containerSize;
        public event AteDelegate EatFood;
        public event GrowDelegate Grow;
        
        //public Snake Snake => _snakeController.Snake;
        public SizeF ControllerSize
        {
            get => _containerSize;
            set
            {
                _containerSize = value;
                _fieldController.ContainerSize = value;
                _snakeController.ContainerSize = value;
                _foodController.ContainerSize = value;
            }
        }

        public Snake Snake => _snakeController.Snake;

        public GameController(SizeF containerSize)
        {
            _fieldController = new FieldController(containerSize);
            _snakeController = new SnakeController(containerSize, _fieldController.F);
            _foodController = new FoodController(containerSize, _fieldController.F, _snakeController.Snake);
        }

        public void PaintScene(Graphics g)
        {
            var bg = BufferedGraphicsManager.Current.Allocate(
                g,
                Rectangle.Round(g.VisibleClipBounds)
            );
            _fieldController.Paint(bg.Graphics);
            _snakeController.Paint(bg.Graphics);
            _foodController.Paint(bg.Graphics);
            bg.Render();
        }

        public bool NextStep()
        {
            var moveResult =  _snakeController.Move();
            var ateResult = _foodController.TryEat();
            if (_shouldGrow)
            {
                _shouldGrow = false;
                Grow(_snakeController.Snake.Length);
            }
            if (ateResult)
            {
                _snakeController.GrowSnake();
                if (EatFood != null) EatFood();
                _shouldGrow = true;
                
            }
            return moveResult;
        }

        public void TurnSnake(Direction way)
        {
            _snakeController.Turn(way);
        }
    }
}
