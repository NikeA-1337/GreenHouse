using System;
using System.Collections.Generic;
using Model.Entity;

namespace Model.Service
{
    public class SetCycleDaysService : ISetCycleDaysService
    {
        public int SelectedDay { get ; set ; }
        private List<DaySchedule> _daySchedules;
        public List<DaySchedule> DaySchedules 
        { 
            get
            {
                return _daySchedules;
            } 
            private set { value = _daySchedules; } 
        }

        private IRepository<Plant> _repository;
        public SetCycleDaysService(IRepository<Plant> repository)
        {
            _repository = repository;
            _daySchedules = new List<DaySchedule>();
        }

        private int _amountOfDays;

        public event Action NewPlantWasAdded;

        public int AmountOfDays 
        { 
            get 
            {
                return _amountOfDays; 
            } 
            set 
            {
                _amountOfDays = value;
            }
        }

        public string PlantName { get ; set ; }

        public void SetSensorsScheduleService(DaySchedule daySchedule)
        {
            foreach (var schedule in DaySchedules)
                if (schedule.Day == daySchedule.Day)
                {
                    DaySchedules[DaySchedules.IndexOf(schedule)] = daySchedule;
                    return;
                }
            DaySchedules.Add(daySchedule);
        }

        public void SaveSchedule()
        {
            Plant plant = new Plant();
            plant.GrowingPlan = DaySchedules;
            plant.Name = PlantName;

            _repository.Add(plant);
            NewPlantWasAdded?.Invoke();
        }
    }
}
