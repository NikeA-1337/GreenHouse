using System;
using System.Collections.Generic;
using System.Linq;
using Model.Entity;

namespace Model.Service
{
    public class SetSensorsScheduleService : ISetSensorsSchduleService
    {

        #region properties
        public int CurrentDay { get; set; }

        // TODO
        // ADD fields verification later

        private string _airTempretureSensorOptimalValue = String.Empty;
        private string _acidSensorOptimalValue = String.Empty;
        private string _nutrientSensorOptimalValue = String.Empty;
        private string _waterTemperatureSensorOptimalValue = String.Empty;
        private string _airTempretureSensorMaxDeviation = String.Empty;
        private string _acidSensorMaxDeviation = String.Empty;
        private string _nutrientSensorMaxDeviation = String.Empty;
        private string _waterTemperatureSensorMaxDeviation = String.Empty;
        public string AirTempretureSensorOptimalValue
        {
            get
            {
                return _airTempretureSensorOptimalValue;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _airTempretureSensorOptimalValue = value;
                }
                else 
                {
                    throw new ArgumentException();
                }
            }
        }
        public string AcidSensorOptimalValue
        {
            get
            {
                return _acidSensorOptimalValue;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _acidSensorOptimalValue = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string NutrientSensorOptimalValue
        {
            get
            {
                return _nutrientSensorOptimalValue;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _nutrientSensorOptimalValue = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string WaterTemperatureSensorOptimalValue
        {
            get
            {
                return _waterTemperatureSensorOptimalValue;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _waterTemperatureSensorOptimalValue = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string AirTempretureSensorMaxDeviation
        {
            get
            {
                return _airTempretureSensorMaxDeviation;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _airTempretureSensorMaxDeviation = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string AcidSensorMaxDeviation
        {
            get
            {
                return _acidSensorMaxDeviation;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _acidSensorMaxDeviation = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string NutrientSensorMaxDeviation
        {
            get
            {
                return _nutrientSensorMaxDeviation;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _nutrientSensorMaxDeviation = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string WaterTemperatureSensorMaxDeviation
        {
            get
            {
                return _waterTemperatureSensorMaxDeviation;
            }
            set
            {
                if (Double.Parse(value) > 0)
                {
                    _waterTemperatureSensorMaxDeviation = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public Time AirTempretureSensorStartTime { get ; set ; } = new Time(default(int), default(int));
        public Time AcidSensorStartHour { get ; set ; } = new Time(default(int), default(int));
        public Time NutrientSensorStartHour { get ; set ; } = new Time(default(int), default(int));
        public Time WaterTemperatureSensorStartHour { get ; set ; } = new Time(default(int), default(int));
        public Time AirTempretureSensorEndTime { get ; set ; } = new Time(default(int), default(int));
        public Time AcidSensorEndTime { get ; set ; } = new Time(default(int), default(int));
        public Time NutrientSensorEndTime { get ; set ; } = new Time(default(int), default(int));
        public Time WaterTemperatureSensorEndTime { get ; set ; } = new Time(default(int), default(int));

        public DaySchedule GenerateDaySchedule()
        {
            DaySchedule daySchedule = new DaySchedule();

            daySchedule.Day = CurrentDay;

            daySchedule.AirTempretureSensorEndTime = AirTempretureSensorEndTime;
            daySchedule.AirTempretureSensorMaxDeviation = AirTempretureSensorMaxDeviation;
            daySchedule.AirTempretureSensorOptimalValue = AirTempretureSensorOptimalValue;
            daySchedule.AirTempretureSensorStartTime = AirTempretureSensorStartTime;

            daySchedule.AcidSensorEndTime = AcidSensorEndTime;
            daySchedule.AcidSensorMaxDeviation = AcidSensorMaxDeviation;
            daySchedule.AcidSensorOptimalValue = AcidSensorOptimalValue;
            daySchedule.AcidSensorStartHour = AcidSensorStartHour;

            daySchedule.NutrientSensorEndTime = NutrientSensorEndTime;
            daySchedule.NutrientSensorMaxDeviation = NutrientSensorMaxDeviation;
            daySchedule.NutrientSensorOptimalValue = NutrientSensorOptimalValue;
            daySchedule.NutrientSensorStartHour = NutrientSensorStartHour;

            daySchedule.WaterTemperatureSensorEndTime = WaterTemperatureSensorEndTime;
            daySchedule.WaterTemperatureSensorMaxDeviation = WaterTemperatureSensorMaxDeviation;
            daySchedule.WaterTemperatureSensorOptimalValue = WaterTemperatureSensorOptimalValue;
            daySchedule.WaterTemperatureSensorStartHour = WaterTemperatureSensorStartHour;
            return daySchedule;
        }

        #endregion properties
    }
}
