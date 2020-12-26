using EnvironmentModulation;
using System;
using static EnvironmentModulation.Environment;

namespace Model.Entity
{

    public abstract class Sensor : EntityBase,IDevice
    {
        public IEnvironment _environment;
        private ITimer _timer;
        public bool IsActive { get; set; }
        public Area Area { get; set; }
        public SensorSchedule SensorSchedule { get; set; }
        public Position Position { get; set; }

        public Sensor(IEnvironment environment,ITimer timer)
        {
            _environment = environment;
            _timer = timer;
            _timer.Interval = 500;
            _timer.Tick += TimerTick;
            _timer.Start();

            SensorSchedule = new SensorSchedule();
        }

        public virtual void TimerTick(object sender, EventArgs e)
        {
            
        }

    }
}
