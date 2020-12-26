using System;

namespace Presentation.Forms
{
    public interface IAddNewPlantForm : IView
    {
        event Action Next;

        string PlantName { get; set; }
        string NumberOfDaysInCycle { get; set; }

        void ShowError(string message);
    }
}
