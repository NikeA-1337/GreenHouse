using static EnvironmentModulation.Environment;

namespace Model.Entity
{
    public class Device : EntityBase,IDevice
    {
        public Position Position { get; set; }
        public bool IsOn { get; set; }
        public Area Area { get; set; }
        public ICommand Command { get; set; }

        public Device()
        {
        }

        public void TurnOn(double value)
        {
            IsOn = true;
            Command.Run(Position,value);
        }

        public void TurnOff()
        {
            IsOn = false;
            Command.Stop(Position);
        }
    }
}
