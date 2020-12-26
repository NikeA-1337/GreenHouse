namespace Model.Service
{
    public interface IAddNewPlantService : IService
    {
        string PlantName { get; set; }
        int NumberOfDaysInCycle { get; set; }
    }
}
