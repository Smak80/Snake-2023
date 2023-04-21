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

        public SizeF ContainerSize
        {
            get => _view.ContainerSize;
            set => _view.ContainerSize = value;
        }
        
        public FieldController(SizeF containerSize)
        {
            _view = new FieldView(containerSize, _f);
        }
        public void Paint(Graphics g)
        {
            _view.Paint(g);
        }
    }
}
