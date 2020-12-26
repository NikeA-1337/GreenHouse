using System;

namespace Presentation.Forms
{
    public interface ISetCycleDaysForm : IView
    {
        event Action Save;
        event Action SetSensorsSchedule;

        int SelectedItemId { get; }
        int AmountOfDays { get; set; }
    }
}
