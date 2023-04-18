using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FieldController
    {
        private Field _f = new Field();
        private FieldView _view;
        public Field F => _f;
        public Graphics MainGraphics
        {
            get => _view.MainGraphics;
            set => _view.MainGraphics = value;
        }

        public FieldController(Graphics g)
        {
            _view = new FieldView(_f, g);
            MainGraphics = g;
        }
        public void Paint()
        {
            _view.Paint();
        }
    }
}
