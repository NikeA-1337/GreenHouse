using EnvironmentModulation;
using Model.Entity;

namespace Model.Commands
{
    public class AirTemperatureHeaterCommand : ICommand
    {
        private IEnvironment _environment;
        public AirTemperatureHeaterCommand(IEnvironment environment)
        {
            _environment = environment;
        }

        public void Run(Position position,double value)
        {
            _environment.SetValueAsConstant(EnvironmentModulation.Environment.Area.AirTemperature, position.x, position.y, value);
        }

        public void Stop(Position position)
        {
            _environment.UnsetValueAsConstant(EnvironmentModulation.Environment.Area.AirTemperature, position.x, position.y);
        }
    }
}
