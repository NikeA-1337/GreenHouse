using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Forms;

namespace GreenHouse
{
    public partial class SetCycleDaysForm : Form,ISetCycleDaysForm
    {
        public int SelectedItemId => listView1.SelectedIndices[0];

        private int _amountOfDays ;
        public int AmountOfDays 
        {
            get { return _amountOfDays; } 
            set {
                _amountOfDays = value;
                listView1.Items.Clear();
                for (int i = 1; i <= _amountOfDays; i++)
                {
                    listView1.Items.Add(i.ToString());
                }
            } 
        }

        public SetCycleDaysForm()
        {
            InitializeComponent();
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
        }  

        public event Action Save;
        public event Action SetSensorsSchedule;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetCycleDaysForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save?.Invoke();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetSensorsSchedule?.Invoke();
        }
    }
}
