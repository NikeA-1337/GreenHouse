using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Service
{
    public interface IMainFormService : IService
    {
        event Action RedrawPictureBox;
        event Action RefreshPictureBox;
        event Action MouseDraggUIElement;
        event Action MouseIsNotDraggingUIElement;
        void RemoveElement(int elementId);
        void AddNewElement(UIElement uIElement);
        void RedrawAllElements();
        void UpdateUISensorsInformation();
        void MoveElement(int xPos,int yPos);


        List<UIElement> UIElements { get; set; }
        List<PassiveSensor> PassiveSensors { get; set; }
        List<ActiveSensor> ActiveSensors { get; set; }
        List<Device> Devices { get; set; }
        Plant GrowingPlant { get; set; }
        int CurrentDay { get; set; }
        Time CurrentTime { get; set; }

        bool IsCycleStarted { get; set; } 
    }
}
