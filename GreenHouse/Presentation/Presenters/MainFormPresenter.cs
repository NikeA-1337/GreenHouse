using System;
using Model;
using Ninject;
using Presentation.Forms;
using Presentation.Presenter;

namespace Presentation
{
    public class MainFormPresenter : AbstractPresenter<IMainForm>
    {
        public MainFormPresenter(IKernel kernel, IServiceFactory serviceFactory, IMainForm view) : base(kernel, serviceFactory, view)
        {
            _view.AddNewDevice += () => AddNewDevice();
            _view.SetCurrentGrowingPlant += () => SetCurrentGrowingPlant();
            _view.StartCycle += () => StartCycle();
            _view.MouseDragging += () => MouseDragging();

            _serviceFactory.CreateMainFormService().RedrawPictureBox += () => RedrawPictureBox();
            _serviceFactory.CreateMainFormService().RedrawPictureBox += () => UpdateDateAndTime();
            _serviceFactory.CreateMainFormService().MouseDraggUIElement += () => SetCursorAsDragging();
            _serviceFactory.CreateMainFormService().MouseIsNotDraggingUIElement += () => SetCursorAsBasic();
        }

        private void AddNewDevice()
        {
            if (!_serviceFactory.CreateMainFormService().IsCycleStarted)
                _kernel.Get<AddDeviceFormPresenter>().Run();
            else
                _view.ShowErrorMessage("Нельзя добавлять новые " +
                    "устройства до завершения текущего цикла");
        }

        private void SetCurrentGrowingPlant()
        {
            if(!_serviceFactory.CreateMainFormService().IsCycleStarted)
                _kernel.Get<SetGrowingPlantFormPresenter>().Run();
            else
                _view.ShowErrorMessage("Нельзя изменять выращиваемое растение " +
                    "до завершения текущего цикла");
        }

        private void StartCycle()
        {
            try
            {
                _serviceFactory.CreateMainFormService().IsCycleStarted = true;
            }
            catch(Exception e)
            {
                _view.ShowErrorMessage("Нельзя запустить цикл " +
                       "до того, как выращиваемое растение выбрано");
            }
        }

        private void RedrawPictureBox()
        {
            _serviceFactory.CreateMainFormService().UpdateUISensorsInformation();
            _view.RedrawPictureBox(_serviceFactory.CreateMainFormService().UIElements);
        }

        private void UpdateDateAndTime()
        {
            _view.SetDateAndTime(_serviceFactory.CreateMainFormService().CurrentDay, _serviceFactory.CreateMainFormService().CurrentTime);
            if (_serviceFactory.CreateMainFormService().IsCycleStarted)
            {
                _view.UpdateProgressBar((int)(((double)_serviceFactory.CreateMainFormService().CurrentDay / (double)_serviceFactory.CreateMainFormService().GrowingPlant.GrowingPlan.Count + (double)_serviceFactory.CreateMainFormService().CurrentTime.Hours / 24 / (double)_serviceFactory.CreateMainFormService().GrowingPlant.GrowingPlan.Count) * 100));
                if (((int)(((double)_serviceFactory.CreateMainFormService().CurrentDay / (double)_serviceFactory.CreateMainFormService().GrowingPlant.GrowingPlan.Count) * 100)) == 100)
                    _serviceFactory.CreateMainFormService().IsCycleStarted = false;
            }
        }

        private void MouseDragging()
        {
            var mouseX = _view.MouseXPosition;
            var mouseY = _view.MouseYPosition;
            if(!_serviceFactory.CreateMainFormService().IsCycleStarted && _view.MouseOnPictureBox)
                _serviceFactory.CreateMainFormService().MoveElement(mouseX, mouseY);
        }

        private void SetCursorAsDragging()
        {
            _view.SetDraggingCursor();
        }

        private void SetCursorAsBasic()
        {
            _view.SetBasicCursor();
        }
    }
}
