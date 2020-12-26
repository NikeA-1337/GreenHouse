using Model.Service;

namespace Model
{
    public interface IServiceFactory
    {
        IMainFormService CreateMainFormService();
        ISetCycleDaysService CreateSetCycleDaysService();
        ISetSensorsSchduleService CreateSetSensorsScheduleService();
        ISetGrowingPlantService CreateSetGrowingPlantService();
        IAddNewPlantService CreateAddNewPlantService();
        IAddNewDeviceService CreateAddNewDeviceService();
    }
}
