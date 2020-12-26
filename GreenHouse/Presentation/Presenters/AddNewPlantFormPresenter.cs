using Model;
using Ninject;
using Presentation.Forms;

namespace Presentation.Presenter
{
    public class AddNewPlantFormPresenter : AbstractPresenter<IAddNewPlantForm>
    {
        public AddNewPlantFormPresenter(IKernel kernel, IServiceFactory serviceFactory, IAddNewPlantForm view) : base(kernel, serviceFactory, view)
        {
            _view.Next += () => Next();
        }

        private void Next()
        {
            var service = _serviceFactory.CreateAddNewPlantService();

            try
            {
                int.TryParse(_view.NumberOfDaysInCycle, out int numberOfDaysInCycle);
                service.NumberOfDaysInCycle = numberOfDaysInCycle;
                service.PlantName = _view.PlantName;
                _kernel.Get<SetCycleDaysFormPresenter>().Run();
                _view.Close();
            }
            catch
            {
                _view.ShowError("Введено некорректное значение");
            }
        }
    }
}
