using Model.Entity;
using Ninject;
using System;
using static EnvironmentModulation.Environment;

namespace Model.Service
{
    public class DeviceFactory : IDeviceFactory
    {
        private IKernel _kernal;
        public DeviceFactory(IKernel kernel)
        {
            _kernal = kernel;
        }
        public IDevice CreateDevice(DeviceType deviceType)
        {
            switch (deviceType)
            {
                case DeviceType.Device:
                    return _kernal.Get<Device>();
                case DeviceType.PasssiveSensor:
                    return _kernal.Get<PassiveSensor>();
                case DeviceType.ActiveSensor:
                    return _kernal.Get<ActiveSensor>();
                default:
                    throw new NotImplementedException();
            }
        }

        public IDevice CreateDevice(DeviceType deviceType, int index)
        {
            switch (deviceType)
            {
                case DeviceType.Device:
                    var device = _kernal.Get<Device>();
                    device.Id = index;
                    return device;
                case DeviceType.PasssiveSensor:
                    var passiveSensor = _kernal.Get<PassiveSensor>();
                    passiveSensor.Id = index;
                    return passiveSensor;
                case DeviceType.ActiveSensor:
                    var activeSensor = _kernal.Get<ActiveSensor>();
                    activeSensor.Id = index;
                    return activeSensor;
                default:
                    throw new NotImplementedException();
            }
        }

        public IDevice CreateDevice(DeviceType deviceType,Area area, int index)
        {
            switch (deviceType)
            {
                case DeviceType.Device:
                    var device = _kernal.Get<Device>();
                    device.Area = area;
                    device.Id = index;
                    return device;
                case DeviceType.PasssiveSensor:
                    var passiveSensor = _kernal.Get<PassiveSensor>();
                    passiveSensor.Area = area;
                    passiveSensor.Id = index;
                    return passiveSensor;
                case DeviceType.ActiveSensor:
                    var activeSensor = _kernal.Get<ActiveSensor>();
                    activeSensor.Area = area;
                    activeSensor.Id = index;
                    return activeSensor;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
