using EnvironmentModulation;

namespace Model.Entity
{
    public class ActiveSensor : Sensor
    {
        private double _baseValue;
        public void Measure()
        {

        }

        public void SetBaseValue(double value)
        {
            _baseValue = value;
        }

        public void SendData()
        {

        }

        public ActiveSensor(IEnvironment environment,ITimer timer) : base(environment,timer)
        {

        }
    }
}
