using static EnvironmentModulation.Environment;

namespace EnvironmentModulation
{
    public interface IEnvironment
    {
        //List<(Area, Cell[][] values)> Matrix { get; set; }

        double GetValue(Area area, int x, int y);
        void SetValueAsConstant(Area area, int x, int y, double value);
        void UnsetValueAsConstant(Area area, int x, int y);
    }
}
