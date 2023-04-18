namespace Snake
{
    public partial class Form1 : Form
    {
        private GameController _controller;
        public Form1()
        {
            InitializeComponent();
            Graphics g = panel1.CreateGraphics();
            _controller = new GameController(g);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            _controller.PaintScene(e.Graphics);
        }
        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (snakeTimer.Enabled)
                snakeTimer.Stop();
            else snakeTimer.Start();
        }

        private void snakeTimer_Tick(object sender, EventArgs e)
        {
            if (!_controller.NextStep())
            {
                snakeTimer.Stop();
            }
            _controller.PaintScene(panel1.CreateGraphics());
        }
    }
}