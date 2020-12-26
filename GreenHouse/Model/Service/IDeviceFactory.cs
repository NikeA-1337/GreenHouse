using Model.Entity;

namespace Model.Service
{
    public interface IDeviceFactory
    {
        IDevice CreateDevice(DeviceType deviceType);
        IDevice CreateDevice(DeviceType deviceType,int index);
    }
}
