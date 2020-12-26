using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Service
{
    public class SetGrowingPlantService : ISetGrowingPlantService
    {
        private List<Plant> Plants { get; set; }
        private string _growingPlantName;
        public string GrowingPlantName { get => _growingPlantName; 
            set 
            {
                Plants = _repository.GetAll();
                if (Plants.Select(p => p.Name).Contains(value))
                {
                    _growingPlantName = value;
                    GrowingPlant = Plants.Where(p => p.Name == _growingPlantName).FirstOrDefault();
                }
                else
                    throw new ArgumentException($"{value} is invalid."); 
            } 
        }

        public Plant GrowingPlant { get ; set ; }

        private IRepository<Plant> _repository;
        private readonly ITimer _timer;
        public SetGrowingPlantService(ITimer timer,IRepository<Plant> repository)
        {
            _repository = repository;
        }

        public List<string> GetAllPlantTitles()
        {
            return _repository.GetAll().Select(p => p.Name).ToList();
        }
    }
}
