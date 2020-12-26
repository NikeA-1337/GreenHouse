using Model.Entity;
using System;
using System.Collections.Generic;

namespace Presentation.Forms
{
    public interface IMainForm : IView
    {
        event Action AddNewDevice;
        event Action SetCurrentGrowingPlant;
        event Action StartCycle;
        event Action MouseDragging;

        void ShowErrorMessage(string message);

        int MouseXPosition { get; set; }
        int MouseYPosition { get; set; }
        bool MouseOnPictureBox { get; set; }

        void RedrawPictureBox(List<UIElement> uIElements);
        void SetBasicCursor();
        void SetDraggingCursor();
        void SetDateAndTime(int day, Time time);
        void UpdateProgressBar(int percent);
    }
}
