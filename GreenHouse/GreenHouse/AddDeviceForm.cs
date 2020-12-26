using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.Entity;
using Presentation.Forms;

namespace GreenHouse
{
    public partial class AddDeviceForm : Form,IAddDeviceForm
    {
        public int SelectedDeviceId { get => listView1.SelectedIndices[0]; }

        public AddDeviceForm()
        {
            InitializeComponent();
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);

        }

        public event Action AddDevice;
        public event Action UpdateListOfDevice;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddDeviceForm_Load(object sender, EventArgs e)
        {
            UpdateListOfDevice?.Invoke();
        }

        private void listView1_MouseDoubleClick(object sender, EventArgs e)
        {
            AddDevice?.Invoke();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void UpdateDeviceList(List<UIElement> uIElements)
        {
            listView1.Items.Clear();

            ImageList imageList = new ImageList();
            foreach (var item in uIElements)
                imageList.Images.Add(item.Image);


            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;

            foreach(var uiElement in uIElements)
            {
                ListViewItem item = new ListViewItem();
                item.Text = uiElement.ElementName;
                listView1.Items.Add(item);
            }
        }

        public void ShowOnlyActiveSensorsCheckBoxStateChanged(object sender, EventArgs e)
        { 
        }

        public void ShowOnlyPassiveSensorsCheckBoxStateChanged(object sender, EventArgs e)
        {
        }

        public void ShowOnlySensorsCheckBoxStateChanged(object sender, EventArgs e)
        {
        }
        public void ShowOnlyDeviceCheckBoxStateChanged(object sender, EventArgs e)
        {
        }
    }
}
