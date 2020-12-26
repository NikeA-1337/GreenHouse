using System;

namespace Model.Service
{
    public class AddNewPlantService : IAddNewPlantService
    {
        private string _plantName;
        private int _numberOfDaysInCycle;
        public string PlantName { get => _plantName; set { if (value.Length > 0) _plantName = value; else throw new ArgumentException($"{value} is empty."); } }
        public int NumberOfDaysInCycle { get => _numberOfDaysInCycle; set { if (value > 0) _numberOfDaysInCycle = value; else throw new ArgumentException($"{value} is negative."); } }
    }
}
