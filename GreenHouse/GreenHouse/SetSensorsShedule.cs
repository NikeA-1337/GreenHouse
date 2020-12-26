using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Entity;
using Presentation.Forms;

namespace GreenHouse
{
    public partial class SetSensorsShedule : Form,ISetSensorsSchedule
    {
        private int _currentDay = -1;

        public event Action FieldUpdate;
        public event Action SaveData;

        public SetSensorsShedule()
        {
            InitializeComponent();

            textBox5.TextChanged += FieldUpdated;
            textBox6.TextChanged += FieldUpdated;
            textBox13.TextChanged += FieldUpdated;
            textBox14.TextChanged += FieldUpdated;
            textBox21.TextChanged += FieldUpdated;
            textBox22.TextChanged += FieldUpdated;
            comboBox11.TextChanged += FieldUpdated;
            comboBox12.TextChanged += FieldUpdated;
            comboBox13.TextChanged += FieldUpdated;
            comboBox14.TextChanged += FieldUpdated;
            comboBox17.TextChanged += FieldUpdated;
            comboBox18.TextChanged += FieldUpdated;
            comboBox21.TextChanged += FieldUpdated;
            comboBox22.TextChanged += FieldUpdated;
            comboBox3.TextChanged += FieldUpdated;
            comboBox4.TextChanged += FieldUpdated;
            comboBox7.TextChanged += FieldUpdated;
            comboBox8.TextChanged += FieldUpdated;

            this.FormClosed += new FormClosedEventHandler(SetSensorsScheduleFormClosed);
        }

        #region textBoxes
        string ISetSensorsSchedule.AirTempretureSensorOptimalValue { get => textBox6.Text; set => throw new NotImplementedException(); }
        string ISetSensorsSchedule.AcidSensorOptimalValue { get => textBox14.Text; set => throw new NotImplementedException(); }
        string ISetSensorsSchedule.WaterTemperatureSensorOptimalValue { get => textBox22.Text; set => throw new NotImplementedException(); }
        string ISetSensorsSchedule.AirTempretureSensorMaxDeviation { get => textBox5.Text; set => throw new NotImplementedException(); }
        string ISetSensorsSchedule.AcidSensorMaxDeviation { get => textBox13.Text; set => throw new NotImplementedException(); }
        string ISetSensorsSchedule.WaterTemperatureSensorMaxDeviation { get => textBox21.Text; set => throw new NotImplementedException(); }

        #endregion textBoxes

        #region sensorsTime

        Time ISetSensorsSchedule.AirTempretureSensorStartTime { get => new Time(comboBox4.Text, comboBox3.Text);set => throw new NotImplementedException(); }
        Time ISetSensorsSchedule.AcidSensorStartHour { get => new Time(comboBox8.Text, comboBox7.Text);set => throw new NotImplementedException(); }
        Time ISetSensorsSchedule.WaterTemperatureSensorStartHour { get => new Time(comboBox12.Text, comboBox11.Text);set => throw new NotImplementedException(); }
        Time ISetSensorsSchedule.AirTempretureSensorEndTime { get => new Time(comboBox22.Text, comboBox21.Text);set => throw new NotImplementedException(); }
        Time ISetSensorsSchedule.AcidSensorEndTime { get => new Time(comboBox18.Text, comboBox17.Text);set => throw new NotImplementedException(); }
        Time ISetSensorsSchedule.WaterTemperatureSensorEndTime { get => new Time(comboBox14.Text, comboBox13.Text);set => throw new NotImplementedException(); }

        #endregion sensorsTime


        private void SetSensorsChedule_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FieldUpdated(object sender, EventArgs e)
        {
            FieldUpdate?.Invoke();
            // Add and verify new info in service
        }

        void SetSensorsScheduleFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveData?.Invoke();
            // Save all form fields
        }

        public void SetCurrentDay(int day)
        {
            _currentDay = day;
            this.Text = $"Настройка работы датчиков для {day} дня ";
        }

        public int GetCurrentDay()
        {
            return _currentDay;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ShowError(string message)
        {
            label35.Text = message;
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
