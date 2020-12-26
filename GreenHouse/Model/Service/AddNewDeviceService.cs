using Model.Entity;
using System.Collections.Generic;

namespace Model.Service
{
    public class AddNewDeviceService : IAddNewDeviceService
    {
        private IRepository<UIElement> _repository;
        private DeviceFactory DeviceFactory { get; set; }
        public AddNewDeviceService(IRepository<UIElement> repository)
        {
            _repository = repository;
        }

        public List<UIElement> GetUIElements()
        {
            return _repository.GetAll();
        }
    }
}
