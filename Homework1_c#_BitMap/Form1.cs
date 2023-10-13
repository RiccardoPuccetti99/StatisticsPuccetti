using System.Drawing;

namespace Homework1_c__BitMap
{
    public partial class Form1 : Form
    {
        private Bitmap m;
        private Graphics g;
        private int x,y;
        public Form1()
        {  
            InitializeComponent();
            m = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            g = Graphics.FromImage(m);
            x = pictureBox1.Width/2;
            y = pictureBox1.Height/2;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            g.FillEllipse(Brushes.Blue, new Rectangle(25, 25, 100, 100)); 
            g.DrawLine(Pens.Green, 25, y - 25, 125, y - 25); 
            g.FillRectangle(Brushes.Orange, new Rectangle(x - 125, 25, 100, 50));
            g.FillEllipse(Brushes.Red, new Rectangle(x - 75, y - 75, 10, 10));

            this.pictureBox1.Image = m;

        }
    }
}