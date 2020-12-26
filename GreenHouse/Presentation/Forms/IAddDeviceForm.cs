using Model.Entity;
using System;
using System.Collections.Generic;

namespace Presentation.Forms
{
    public interface IAddDeviceForm : IView
    {
        event Action AddDevice;
        event Action UpdateListOfDevice;

        int SelectedDeviceId { get;}
        void UpdateDeviceList(List<UIElement> uIElements);
    }
}
