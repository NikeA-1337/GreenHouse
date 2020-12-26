namespace Model.Entity
{
    public interface ICommand
    {
        void Run(Position position,double value);
        void Stop(Position position);
    }
}
