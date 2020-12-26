using System;
using static EnvironmentModulation.Environment;

namespace Model.Entity
{
    public class DaySchedule
    {
        public SensorSchedule this[Area area]
        {
            get 
            {
                var sensorSchedule = new SensorSchedule();
                switch (area)
                {
                    case Area.AirTemperature:
                        sensorSchedule.MaxDeviation = double.Parse(AirTempretureSensorMaxDeviation);
                        sensorSchedule.OptimalValue = double.Parse(AirTempretureSensorOptimalValue);
                        sensorSchedule.SensorEndTime = AirTempretureSensorEndTime;
                        sensorSchedule.SensorStartTime = AirTempretureSensorStartTime;
                        return sensorSchedule;
                    case Area.Acid:
                        sensorSchedule.MaxDeviation = double.Parse(AcidSensorMaxDeviation);
                        sensorSchedule.OptimalValue = double.Parse(AcidSensorOptimalValue);
                        sensorSchedule.SensorEndTime = AcidSensorEndTime;
                        sensorSchedule.SensorStartTime = AcidSensorStartHour;
                        return sensorSchedule;
                    case Area.WaterTemperature:
                        sensorSchedule.MaxDeviation = double.Parse(WaterTemperatureSensorMaxDeviation);
                        sensorSchedule.OptimalValue = double.Parse(WaterTemperatureSensorOptimalValue);
                        sensorSchedule.SensorEndTime = WaterTemperatureSensorEndTime;
                        sensorSchedule.SensorStartTime = WaterTemperatureSensorStartHour;
                        return sensorSchedule;
                    case Area.Nutrient:
                        sensorSchedule.MaxDeviation = double.Parse(NutrientSensorMaxDeviation);
                        sensorSchedule.OptimalValue = double.Parse(NutrientSensorOptimalValue);
                        sensorSchedule.SensorEndTime = NutrientSensorEndTime;
                        sensorSchedule.SensorStartTime = NutrientSensorStartHour;
                        return sensorSchedule;
                    default:
                        throw new NotImplementedException();
                }
            }
            set { }
        }

        public int Day;

        public string AirTempretureSensorOptimalValue { get ; set ; }
        public string AcidSensorOptimalValue { get ; set ; }
        public string NutrientSensorOptimalValue { get ; set ; }
        public string WaterTemperatureSensorOptimalValue { get ; set ; }
        public string AirTempretureSensorMaxDeviation { get ; set ; }
        public string AcidSensorMaxDeviation { get ; set ; }
        public string NutrientSensorMaxDeviation { get ; set ; }
        public string WaterTemperatureSensorMaxDeviation { get ; set ; }
        public Time AirTempretureSensorStartTime { get ; set ; }
        public Time AcidSensorStartHour { get ; set ; }
        public Time NutrientSensorStartHour { get ; set ; }
        public Time WaterTemperatureSensorStartHour { get ; set ; }
        public Time AirTempretureSensorEndTime { get ; set ; }
        public Time AcidSensorEndTime { get ; set ; }
        public Time NutrientSensorEndTime { get ; set ; }
        public Time WaterTemperatureSensorEndTime { get ; set ; }
    }
}
