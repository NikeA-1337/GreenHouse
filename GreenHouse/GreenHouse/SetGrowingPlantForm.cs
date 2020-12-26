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
    public partial class SetGrowingPlantForm : Form,ISetGrowingPlantForm
    {
        public SetGrowingPlantForm()
        {
            InitializeComponent();
        }

        private void SetGrowingPlantForm_Load(object sender, EventArgs e)
        {
            UpdatePlantList?.Invoke();
        }
        
        public event Action Accept;
        public event Action AddNewPlant;
        public event Action UpdatePlantList;

        public string PlantName { get; set; }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlantName = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewPlant?.Invoke();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Accept?.Invoke();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ShowError(string message)
        {
            label1.Text = message;
        }

        public void UpdateAvailablePlants(List<string> plants)
        {
            comboBox1.Items.Clear();
            foreach (var item in plants)
                comboBox1.Items.Add(item);
        }

    }
}
