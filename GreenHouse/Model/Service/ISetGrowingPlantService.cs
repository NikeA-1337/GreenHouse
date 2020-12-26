using Model.Entity;
using System.Collections.Generic;

namespace Model.Service
{
    public interface ISetGrowingPlantService : IService
    {
        string GrowingPlantName { get; set; }
        Plant GrowingPlant { get; set; }
        List<string> GetAllPlantTitles();
    }
}
