namespace Model.Commands
{
    public interface ICommandFactory
    {
        AcidRegulatorCommand CreateAcidRegulatorCommand();
        AirTemperatureHeaterCommand CreateAirTemperatureHeaterCommand();
        WaterTemperatureHeaterCommand CreateWaterTemperatureHeaterCommand();
        NutrientRegulatorCommand CreateNutrientRegulatorCommand();
    }
}
