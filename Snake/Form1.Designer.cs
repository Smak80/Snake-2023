namespace Snake
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            snakeTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(566, 517);
            panel1.TabIndex = 0;
            panel1.SizeChanged += panel1_SizeChanged;
            panel1.Click += panel1_Click;
            panel1.Paint += panel1_Paint;
            // 
            // snakeTimer
            // 
            snakeTimer.Interval = 1000;
            snakeTimer.Tick += snakeTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 541);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Змейка";
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private System.Windows.Forms.Timer snakeTimer;
    }
}