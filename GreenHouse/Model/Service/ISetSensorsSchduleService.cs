using Model.Entity;

namespace Model.Service
{
    public interface ISetSensorsSchduleService : IService
    {
        #region properties
        int CurrentDay { get; set; }


        string AirTempretureSensorOptimalValue { get; set; }
        string AcidSensorOptimalValue { get; set; }
        string NutrientSensorOptimalValue { get; set; }
        string WaterTemperatureSensorOptimalValue { get; set; }
        string AirTempretureSensorMaxDeviation { get; set; }
        string AcidSensorMaxDeviation { get; set; }
        string NutrientSensorMaxDeviation { get; set; }
        string WaterTemperatureSensorMaxDeviation { get; set; }
        Time AirTempretureSensorStartTime { get; set; }
        Time AcidSensorStartHour { get; set; }
        Time NutrientSensorStartHour { get; set; }
        Time WaterTemperatureSensorStartHour { get; set; }
        Time AirTempretureSensorEndTime { get; set; }
        Time AcidSensorEndTime { get; set; }
        Time NutrientSensorEndTime { get; set; }
        Time WaterTemperatureSensorEndTime { get; set; }
        #endregion properties

        DaySchedule GenerateDaySchedule();
    }
}
