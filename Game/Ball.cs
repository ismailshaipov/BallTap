using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ball: Control
    {
        private Random r = new();
        private int _cnt = 0;
        private bool entered = false;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private Random random = new Random();

        public Ball()
        {
            _timer.Interval = 5000;
            _timer.Enabled = true;
            _timer.Tick += timer_Tick;
            Size = new Size(100, 100);
            Font = new Font("Cambria", 16, FontStyle.Bold);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var b = new SolidBrush(ForeColor);
            e.Graphics.FillEllipse(b, 0, 0, Width, Height);
            var sm = e.Graphics.MeasureString(_cnt.ToString(), Font);
            e.Graphics.DrawString(
                _cnt.ToString(),
                Font,
                new SolidBrush(BackColor),
                Width / 2 - sm.Width / 2, Height / 2 - sm.Height / 2);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            entered = true;

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            _cnt++;
            _timer.Interval = (int)Math.Max(50, _timer.Interval * 0.8);
            ForeColor = Color.FromArgb(
                   random.Next(255),
                   random.Next(255),
                   random.Next(255)
               );
            Refresh();
            Move();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (entered)
            {
                Move();
                entered = false;
            }
        }

        private void Move()
        {
            var x = r.Next(Parent.Width - Width);
            var y = r.Next(Parent.Height - Height);
            Location = new Point(x, y);
        }
    }
}