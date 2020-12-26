using System;
using Model;
using Model.Entity;
using Ninject;
using Presentation.Forms;

namespace Presentation.Presenter
{
    public class SetSensorsSchedulePresenter : AbstractPresenter<ISetSensorsSchedule>
    {
        public SetSensorsSchedulePresenter(IKernel kernel, IServiceFactory serviceFactory, ISetSensorsSchedule view) : base(kernel, serviceFactory, view)
        {
            _view.SaveData += () => SaveData();
            _view.FieldUpdate += () => FieldUpdated();

            _view.SetCurrentDay(_serviceFactory.CreateSetCycleDaysService().SelectedDay);
            _serviceFactory.CreateSetSensorsScheduleService().CurrentDay =
                _serviceFactory.CreateSetCycleDaysService().SelectedDay;

        }

        private void SaveData()
        {
            DaySchedule daySchedule = _serviceFactory.CreateSetSensorsScheduleService().GenerateDaySchedule();

            _serviceFactory.CreateSetCycleDaysService().SetSensorsScheduleService(daySchedule);
        }

        private void FieldUpdated()
        {
            try
            {
                _serviceFactory.CreateSetSensorsScheduleService().AcidSensorMaxDeviation = _view.AcidSensorMaxDeviation;
                _serviceFactory.CreateSetSensorsScheduleService().AcidSensorEndTime = _view.AcidSensorEndTime;
                _serviceFactory.CreateSetSensorsScheduleService().AcidSensorOptimalValue = _view.AcidSensorOptimalValue;
                _serviceFactory.CreateSetSensorsScheduleService().AcidSensorStartHour = _view.AcidSensorStartHour;

                _serviceFactory.CreateSetSensorsScheduleService().AirTempretureSensorEndTime = _view.AirTempretureSensorEndTime;
                _serviceFactory.CreateSetSensorsScheduleService().AirTempretureSensorMaxDeviation = _view.AirTempretureSensorMaxDeviation;
                _serviceFactory.CreateSetSensorsScheduleService().AirTempretureSensorOptimalValue = _view.AirTempretureSensorOptimalValue;
                _serviceFactory.CreateSetSensorsScheduleService().AirTempretureSensorStartTime = _view.AirTempretureSensorStartTime;

                _serviceFactory.CreateSetSensorsScheduleService().WaterTemperatureSensorEndTime = _view.WaterTemperatureSensorEndTime;
                _serviceFactory.CreateSetSensorsScheduleService().WaterTemperatureSensorMaxDeviation = _view.WaterTemperatureSensorMaxDeviation;
                _serviceFactory.CreateSetSensorsScheduleService().WaterTemperatureSensorOptimalValue = _view.WaterTemperatureSensorOptimalValue;
                _serviceFactory.CreateSetSensorsScheduleService().WaterTemperatureSensorStartHour = _view.WaterTemperatureSensorStartHour;
            }catch(Exception e)
            {
                _view.ShowError("Одно из полей заполнено неверно!");
            }
        }
    }
}
