using Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation;
using Presentation.Forms;
using Presentation.Presenter;
using Ninject.Extensions.Factory;
using Model.Service;
using Model;
using DAL.Repository;
using Model.Entity;
using EnvironmentModulation;
using Model.Commands;
using static EnvironmentModulation.Environment;

namespace GreenHouse
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Ninject.StandardKernel kernel = new StandardKernel();
            kernel.Bind<ApplicationContext>().ToConstant(new ApplicationContext());

            kernel.Bind<ITimer>().To<WinFormTimer>();

            kernel.Bind<IServiceFactory>().ToFactory();
            kernel.Bind<ICommandFactory>().ToFactory();

            kernel.Bind<IAddNewPlantForm>().To<AddNewPlantForm>();
            kernel.Bind<IAddDeviceForm>().To<AddDeviceForm>();
            kernel.Bind<ISetCycleDaysForm>().To<SetCycleDaysForm>();
            kernel.Bind<ISetGrowingPlantForm>().To<SetGrowingPlantForm>();
            kernel.Bind<ISetSensorsSchedule>().To<SetSensorsShedule>();
            kernel.Bind<IMainForm>().To<MainForm>();


            kernel.Bind<IMainFormService>().To<MainFormService>().InSingletonScope();
            kernel.Bind<ISetCycleDaysService>().To<SetCycleDaysService>().InSingletonScope();
            kernel.Bind<ISetSensorsSchduleService>().To<SetSensorsScheduleService>().InSingletonScope();
            kernel.Bind<IAddNewDeviceService>().To<AddNewDeviceService>().InSingletonScope();
            kernel.Bind<ISetGrowingPlantService>().To<SetGrowingPlantService>().InSingletonScope();
            kernel.Bind<IAddNewPlantService>().To<AddNewPlantService>().InSingletonScope();
            kernel.Bind<IDeviceFactory>().To<DeviceFactory>();

            kernel.Bind<IRepository<UIElement>>().To<ImageRepository>().InSingletonScope();
            kernel.Bind<IRepository<Plant>>().To<PlantRepository>().InSingletonScope();

            kernel.Bind<AddNewPlantFormPresenter>().ToSelf();
            kernel.Bind<AddDeviceFormPresenter>().ToSelf();
            kernel.Bind<SetCycleDaysFormPresenter>().ToSelf();
            kernel.Bind<SetGrowingPlantFormPresenter>().ToSelf();
            kernel.Bind<SetSensorsSchedulePresenter>().ToSelf();
            kernel.Bind<MainFormPresenter>().ToSelf();


            kernel.Bind<Device>().ToSelf();
            kernel.Bind<ActiveSensor>().ToSelf();
            kernel.Bind<PassiveSensor>().ToSelf();

            kernel.Bind<IEnvironment>().To<EnvironmentModulation.Environment>().InSingletonScope();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            kernel.Bind<InitImageRepository>().ToSelf();
            kernel.Bind<InitPlantRepository>().ToSelf();

            kernel.Get<InitPlantRepository>().Init();
            kernel.Get<InitImageRepository>().Init();

            kernel.Get<MainFormPresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }

        // Wrapper around system timer to pass it as ITimer implementer
        internal class WinFormTimer : Timer, ITimer { }



        /// <summary>
        /// TODO: implement file reading one day?
        /// </summary>
        private class InitPlantRepository
        {
            private IRepository<Plant> _repository;
            public InitPlantRepository(IRepository<Plant> repository)
            {
                _repository = repository;
            }
            public void Init()
            {
                Plant cucumber = new Plant();
                cucumber.Name = "Огурцы";
                List<DaySchedule> daySchedules = new List<DaySchedule>();

                for(int i = 0; i < 5; i++)
                {
                    var daySchedule = new DaySchedule();
                    daySchedule.Day = i;
                    daySchedule.AcidSensorMaxDeviation = "7";
                    daySchedule.AcidSensorEndTime = new Time(new Random().Next(23), new Random().Next(59));
                    daySchedule.AcidSensorOptimalValue = (new Random().NextDouble() * 45 + 1).ToString();
                    daySchedule.AcidSensorStartHour = new Time(new Random().Next(23), new Random().Next(59));

                    daySchedule.AirTempretureSensorEndTime = new Time(new Random().Next(23), new Random().Next(59));
                    daySchedule.AirTempretureSensorMaxDeviation = "7";
                    daySchedule.AirTempretureSensorOptimalValue = (new Random().NextDouble() * 45 + 1).ToString();
                    daySchedule.AirTempretureSensorStartTime = new Time(new Random().Next(23), new Random().Next(59));

                    daySchedule.WaterTemperatureSensorEndTime = new Time(new Random().Next(23), new Random().Next(59));
                    daySchedule.WaterTemperatureSensorMaxDeviation = "7";
                    daySchedule.WaterTemperatureSensorOptimalValue = (new Random().NextDouble() * 45 + 1).ToString();
                    daySchedule.WaterTemperatureSensorStartHour = new Time(new Random().Next(23), new Random().Next(59));

                    daySchedule.NutrientSensorEndTime = new Time(new Random().Next(23), new Random().Next(59));
                    daySchedule.NutrientSensorMaxDeviation = "7";
                    daySchedule.NutrientSensorOptimalValue = (new Random().NextDouble() * 45 + 1).ToString();
                    daySchedule.NutrientSensorStartHour = new Time(new Random().Next(23), new Random().Next(59));
                    daySchedules.Add(daySchedule);

                }
                cucumber.GrowingPlan = daySchedules;

                Plant kaef = new Plant();
                kaef.Name = "Перец";
                kaef.GrowingPlan = daySchedules;

                _repository.Add(cucumber);
                _repository.Add(kaef);
            }
        }

        private class InitImageRepository
        {
            private IRepository<UIElement> _repository;
            public InitImageRepository(IRepository<UIElement> repository)
            {
                _repository = repository;
            }
            public void Init()
            {
                UIElement heater = new UIElement("Обогреватель", DeviceType.Device, Area.AirTemperature, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\heater.png", 196, 165);
                UIElement water = new UIElement("Увлажнитель", DeviceType.Device, Area.WaterTemperature, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\vlazhniy.png", 196, 165);
                UIElement nutrient = new UIElement("Дозатор удобрений", DeviceType.Device, Area.Nutrient, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\dozator.png", 196, 165);

                UIElement acidSensor = new UIElement("Датчик кислотности", DeviceType.PasssiveSensor, Area.Acid, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\kisliy.png", 196, 165);
                UIElement waterTempSensor = new UIElement("Датчик температуры воды", DeviceType.ActiveSensor, Area.WaterTemperature, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\water.png", 196, 165);
                UIElement nutrientSensor = new UIElement("Датчик температуры воздуха", DeviceType.PasssiveSensor, Area.AirTemperature, @"d:\Дистанционноу обучение\3 курс\Технологии программирования\img\thermometer.png", 196, 165);
                _repository.Add(heater);
                _repository.Add(nutrient);
                _repository.Add(water);

                _repository.Add(waterTempSensor);
                _repository.Add(nutrientSensor);
                _repository.Add(acidSensor);
            }
        }
    }
}
