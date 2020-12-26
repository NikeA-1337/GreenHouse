using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model.Entity;
using Presentation.Forms;

namespace GreenHouse
{
    public partial class MainForm : Form,IMainForm
    {
        public MainForm(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _applicationContext.MainForm = this;
            InitializeComponent();

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;

        }

        public event Action MouseDragging;

        private readonly ApplicationContext _applicationContext;

        public event Action AddNewDevice;
        public event Action SetCurrentGrowingPlant;
        public event Action StartCycle;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartCycle?.Invoke();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetCurrentGrowingPlant?.Invoke();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddNewDevice?.Invoke();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void RedrawPictureBox(List<UIElement> uIElements)
        {
            pictureBox1.Image = null;
            
            Bitmap bitmap = new Bitmap(1000,1000);
            Graphics graphics = Graphics.FromImage(bitmap);

            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            foreach (var uiElement in uIElements)
            {
                graphics.DrawImage(uiElement.Image, new Point(uiElement.Position.x, uiElement.Position.y));
                graphics.DrawString(uiElement.CurrentState.ToString(), drawFont, drawBrush, uiElement.Position.x+5, uiElement.Position.y-16);
            }

            pictureBox1.Image = bitmap;
        }

        #region dragging
        public bool MouseOnPictureBox { get; set; }
        public int MouseXPosition { get; set; }
        public int MouseYPosition { get; set; }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {  }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDragging?.Invoke();
                MouseXPosition = e.X;
                MouseYPosition = e.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse moving
            if (e.Button == MouseButtons.Left)
            {
                MouseXPosition = e.X;
                MouseYPosition = e.Y;

                //label1.Text = "cursor :  x = " + MouseXPosition + " y = " + MouseYPosition + "MouseOnPictureBox = " + MouseOnPictureBox;

                MouseDragging?.Invoke();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            MouseOnPictureBox = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            MouseOnPictureBox = false;
        }
        #endregion dragging



        public void SetBasicCursor()
        {
            Cursor.Current = Cursors.Default;
        }

        public void SetDraggingCursor()
        {
            Cursor.Current = Cursors.Hand;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void SetDateAndTime(int day, Time time)
        {
            label1.Text = $"Текущий день цикла {day} ,текущее время {time.Hours} часов {time.Minutes} минут .";
        }

        public void UpdateProgressBar(int percent)
        {
            progressBar1.Value = percent;
            label2.Text = $"{percent}%";
        }
    }
}
