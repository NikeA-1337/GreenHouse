using System;
using System.Collections.Generic;
using System.Linq;
using Model.Commands;
using Model.Entity;
using static EnvironmentModulation.Environment;

namespace Model.Service
{
    public class MainFormService : IMainFormService
    {
        private readonly ITimer _timer;
        private readonly IDeviceFactory _deviceFactory;
        private readonly ICommandFactory _commandFactory;
        private int _numberOfTicks = 0;
        private int _item_counter = 0;

        public event Action RedrawPictureBox;
        public event Action RefreshPictureBox;
        public event Action MouseDraggUIElement;
        public event Action MouseIsNotDraggingUIElement;

        public List<UIElement> UIElements { get; set; } = new List<UIElement>();
        public List<Device> Devices { get; set; } = new List<Device>();
        public Plant GrowingPlant { get ; set ; }
        private bool _isCycleStarted = false;
        public bool IsCycleStarted { get { return _isCycleStarted; } set { if (GrowingPlant.Name == string.Empty) { throw new ArgumentException(); } _isCycleStarted = value; } }
        public int CurrentDay { get; set; } = 0;
        public Time CurrentTime { get; set; } = new Time(0,0);
        public List<PassiveSensor> PassiveSensors { get; set; } = new List<PassiveSensor>();
        public List<ActiveSensor> ActiveSensors { get; set; } = new List<ActiveSensor>();

        public MainFormService(ITimer timer, IRepository<UIElement> repository,IDeviceFactory deviceFactory,ICommandFactory commandFactory)
        {
            _deviceFactory = deviceFactory;
            _commandFactory = commandFactory;
            _timer = timer;
            _timer.Interval = 5;
            _timer.Tick += TimerTick;
            _timer.Start();

            //UIElements = new List<UIElement>();

        }

        private void TimerTick(object sender, EventArgs e)
        {
            RedrawAllElements();
            _numberOfTicks++;
            if (IsCycleStarted)
            {
                RecalculateTime();
                ControlSystem();
            }
        }

        public void RemoveElement(int elementId)
        {
        }

        public void RedrawAllElements()
        {
            RedrawPictureBox?.Invoke();
        }

        public void AddNewElement(UIElement uIElement)
        {
            uIElement.Id = _item_counter;
            UIElements.Add(uIElement);
            IDevice device = _deviceFactory.CreateDevice(uIElement.DeviceType,_item_counter);
            device.Position = uIElement.Position;
            switch (uIElement.DeviceType)
            {
                case DeviceType.Device:
                    Device temp_device = (Device)device; 
                    switch(uIElement.Area)
                    {
                        case Area.AirTemperature:
                            temp_device.Command = _commandFactory.CreateAirTemperatureHeaterCommand();
                            break;
                        case Area.WaterTemperature:
                            temp_device.Command = _commandFactory.CreateWaterTemperatureHeaterCommand();
                            break;
                        case Area.Nutrient:
                            temp_device.Command = _commandFactory.CreateNutrientRegulatorCommand();
                            break;
                        case Area.Acid:
                            temp_device.Command = _commandFactory.CreateAcidRegulatorCommand();
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    Devices.Add(temp_device);
                    break;
                case DeviceType.ActiveSensor:
                    ActiveSensors.Add(device as ActiveSensor);
                    break;
                case DeviceType.PasssiveSensor:
                    PassiveSensors.Add(device as PassiveSensor);
                    break;
                default:
                    throw new NotImplementedException();
            }
            _item_counter++;
        }

        public void MoveElement(int xPos, int yPos)
        {
            foreach (var element in UIElements)
            {
                if (Math.Abs(element.Position.x - xPos) < 20 && Math.Abs(element.Position.y - yPos) < 20)
                {
                    MouseDraggUIElement.Invoke();
                    element.Position.x = xPos;
                    element.Position.y = yPos;

                    foreach (var device in Devices)
                        if (device.Id == element.Id)
                            device.Position = element.Position;
                    foreach (var device in PassiveSensors)
                        if (device.Id == element.Id)
                            device.Position = element.Position;
                }
                else {
                    MouseIsNotDraggingUIElement.Invoke(); 
                }
            }
        }

        private void RecalculateTime()
        {
            if(_numberOfTicks % 60 == 0)
            {
                CurrentTime.Minutes = 30;

                if (CurrentTime.Hours == 0 && CurrentTime.Minutes == 0)
                    CurrentDay++;
            }
        }

        private void ControlSystem()
        {
            DaySchedule currentDaySchedule = GrowingPlant.GrowingPlan[CurrentDay];
            foreach(var sensor in PassiveSensors)
            {
                var sensorShcedule = currentDaySchedule[sensor.Area];
                var UISensor = UIElements.Where(e => e.Id == sensor.Id).FirstOrDefault();
                UISensor.CurrentState = sensor.GetData().ToString();
                if(Math.Abs(sensor.GetData() - sensorShcedule.OptimalValue) > sensorShcedule.MaxDeviation)
                {
                    foreach (var device in Devices)
                        if (device.Area == sensor.Area)
                        {
                            device.TurnOn(sensorShcedule.OptimalValue);
                            UIElements.Where(e => e.Id == device.Id).ToList().ForEach(e => e.CurrentState = "Active");
                        }
                }
                else
                {
                    foreach (var device in Devices)
                        if (device.Area == sensor.Area)
                        {
                            device.TurnOff();
                            UIElements.Where(e => e.Id == device.Id).ToList().ForEach(e => e.CurrentState = "Off");
                        }
                }
            }

        }

        public void UpdateUISensorsInformation()
        {
            foreach (var passiveSensor in PassiveSensors)
                UIElements.Where(e => e.Id == passiveSensor.Id).FirstOrDefault().CurrentState = passiveSensor.GetData().ToString();

            // TODO later implement Active sensors
        }
    }
}
