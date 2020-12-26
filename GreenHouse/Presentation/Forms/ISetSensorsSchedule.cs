using Model.Entity;
using System;

namespace Presentation.Forms
{
    public interface ISetSensorsSchedule : IView
    {
        event Action FieldUpdate;
        event Action SaveData;

        void ShowError(string message);

        void SetCurrentDay(int day);
        int GetCurrentDay();

        #region properties
        string AirTempretureSensorOptimalValue { get; set; }
        string AcidSensorOptimalValue { get; set; }
        string WaterTemperatureSensorOptimalValue { get; set; }
        string AirTempretureSensorMaxDeviation { get; set; }
        string AcidSensorMaxDeviation { get; set; }
        string WaterTemperatureSensorMaxDeviation { get; set; }
        Time AirTempretureSensorStartTime { get; set; }
        Time AcidSensorStartHour { get; set; }
        Time WaterTemperatureSensorStartHour { get; set; }
        Time AirTempretureSensorEndTime { get; set; }
        Time AcidSensorEndTime { get; set; }
        Time WaterTemperatureSensorEndTime { get; set; }
        #endregion properties
    }
}
