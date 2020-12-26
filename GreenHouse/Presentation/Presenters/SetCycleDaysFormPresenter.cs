using Model;
using Ninject;
using Presentation.Forms;

namespace Presentation.Presenter
{
    public class SetCycleDaysFormPresenter : AbstractPresenter<ISetCycleDaysForm>
    {
        public SetCycleDaysFormPresenter(IKernel kernel, IServiceFactory serviceFactory, ISetCycleDaysForm view) : base(kernel, serviceFactory, view)
        {
            _view.SetSensorsSchedule += () => SetSensorsSchedule();
            _view.Save += () => Save();

            _serviceFactory.CreateSetCycleDaysService().AmountOfDays = serviceFactory.CreateAddNewPlantService().NumberOfDaysInCycle;
            _serviceFactory.CreateSetCycleDaysService().PlantName = serviceFactory.CreateAddNewPlantService().PlantName;
            _view.AmountOfDays = serviceFactory.CreateAddNewPlantService().NumberOfDaysInCycle;
        }

        private void SetSensorsSchedule()
        {
            _serviceFactory.CreateSetCycleDaysService().SelectedDay = _view.SelectedItemId + 1; // selected item starts with zero
            _kernel.Get<SetSensorsSchedulePresenter>().Run();
        }

        private void Save()
        {
            _serviceFactory.CreateSetCycleDaysService().SaveSchedule();
            _view.Close();
        }
    }
}
