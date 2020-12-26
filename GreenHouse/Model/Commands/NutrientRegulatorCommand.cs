using EnvironmentModulation;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Commands
{
    public class NutrientRegulatorCommand : ICommand
    {
        private IEnvironment _environment;
        public NutrientRegulatorCommand(IEnvironment environment)
        {
            _environment = environment;
        }

        public void Run(Position position,double value)
        {
            _environment.SetValueAsConstant(EnvironmentModulation.Environment.Area.Nutrient, position.x, position.y, value);
        }

        public void Stop(Position position)
        {
            _environment.UnsetValueAsConstant(EnvironmentModulation.Environment.Area.Nutrient, position.x, position.y);
        }
    }
}
