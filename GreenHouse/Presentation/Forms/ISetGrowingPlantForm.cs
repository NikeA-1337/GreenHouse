using System;
using System.Collections.Generic;

namespace Presentation.Forms
{
    public interface ISetGrowingPlantForm : IView
    {
        event Action Accept;
        event Action AddNewPlant;
        event Action UpdatePlantList;

        string PlantName { get; set; }

        void ShowError(string message);
        void UpdateAvailablePlants(List<string> plants);
    }
}
