using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Service
{
    public interface ISetCycleDaysService : IService
    {
        event Action NewPlantWasAdded;
        int SelectedDay { get; set; }
        int AmountOfDays { get; set; }
        string PlantName { get; set; }
        List<DaySchedule> DaySchedules { get; }
        void SetSensorsScheduleService(DaySchedule daySchedule);
        void SaveSchedule();
    }
}
