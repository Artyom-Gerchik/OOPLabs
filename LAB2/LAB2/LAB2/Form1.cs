namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        private bool isMouseClicked = false;

        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;

            public ArrayPoints(int size)
            {
                if (size <= 0)
                {
                    size = 2;
                }
                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (index >= points.Length)
                {
                    index = 0;
                }

                points[index] = new Point(x, y);
                index++;

            }

            public void Resetpoints()
            {
                index = 0;
            }

            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }

        }

        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap map = new Bitmap(100, 100); // to save img
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f);


        private void SetSize()
        {
            Rectangle userScreen = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(userScreen.Width, userScreen.Height);
            graphics = Graphics.FromImage(map);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Width = PenWidth.Value;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseClicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseClicked = false;
            arrayPoints.Resetpoints();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseClicked)
            {
                return;
            }
            else
            {
                if (FreeFormat.Checked)
                {
                    arrayPoints.SetPoint(e.X, e.Y);
                    if (arrayPoints.GetCountPoints() >= 2)
                    {
                        graphics.DrawLines(pen, arrayPoints.GetPoints());
                        pictureBox1.Image = map;
                        arrayPoints.SetPoint((int)e.X, (int)e.Y);
                    }
                }
                else
                {


                }
            }


        }

        private void Color1_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void RGB_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void ClearTheCanvas_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = PenWidth.Value;
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG(*.PNG)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }
    }
}