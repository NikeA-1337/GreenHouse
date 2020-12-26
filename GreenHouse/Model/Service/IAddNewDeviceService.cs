using Model.Entity;
using System.Collections.Generic;

namespace Model.Service
{
    public interface IAddNewDeviceService : IService
    {
        List<UIElement> GetUIElements();
    }
}
