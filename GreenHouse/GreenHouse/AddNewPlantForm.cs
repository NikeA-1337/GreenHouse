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
    public partial class AddNewPlantForm : Form,IAddNewPlantForm
    {
        public AddNewPlantForm()
        {
            InitializeComponent();
        }

        public event Action Next;


        public string PlantName { get => textBox1.Text; set => throw new NotImplementedException(); }
        public string NumberOfDaysInCycle { get => textBox2.Text; set => throw new NotImplementedException(); }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddNewPlantForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Next?.Invoke();
        }

        public void ShowError(string message)
        {
            label1.Text = message;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
