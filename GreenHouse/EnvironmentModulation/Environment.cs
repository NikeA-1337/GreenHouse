using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EnvironmentModulation
{
    public class Environment : IEnvironment
    {
        public static List<(Area, Cell[,] values)> Matrix { get; set; }

        public enum Area
        {
            AirTemperature,
            WaterTemperature,
            Nutrient,
            Acid
        }

        public class Cell
        {
            public Cell()
            {
                value = 0;
                IsConst = false;
            }
            public double value;
            public bool IsConst;
        }

        public Environment()
        {
            Matrix = new List<(Area, Cell[,] values)>();
            Matrix.Add((Area.AirTemperature, InitMatrix(new Cell[60,60])));
            Matrix.Add((Area.WaterTemperature, InitMatrix(new Cell[60, 60])));
            Matrix.Add((Area.Acid, InitMatrix(new Cell[60, 60])));
            Matrix.Add((Area.Nutrient, InitMatrix(new Cell[60, 60])));

            Thread AirThread = new Thread(new ParameterizedThreadStart(RecalculateMatrix));
            Thread AcidThread = new Thread(new ParameterizedThreadStart(RecalculateMatrix));
            Thread WaterThread = new Thread(new ParameterizedThreadStart(RecalculateMatrix));
            Thread NutrientThread = new Thread(new ParameterizedThreadStart(RecalculateMatrix));
            AirThread.Start(Area.AirTemperature);
            AcidThread.Start(Area.Acid);
            WaterThread.Start(Area.WaterTemperature);
            NutrientThread.Start(Area.Nutrient);
        }

        public double GetValue(Area area , int x , int y)
        {
            int x_m = x / 10;
            int y_m = y / 10;

            var values = Matrix.Where(m => m.Item1 == area).Select(m => m.values).FirstOrDefault();
            return values[x_m,y_m].value;
        }

        public void SetValueAsConstant(Area area, int x, int y,double value)
        {
            int x_m = x / 10;
            int y_m = y / 10;

            var newValue = new Cell();
            newValue.value = value;
            newValue.IsConst = true;

            var values = Matrix.Where(m => m.Item1 == area).Select(m => m.values).FirstOrDefault();
            values[x_m,y_m] = newValue; 
        }

        public void UnsetValueAsConstant(Area area, int x, int y)
        {
            int x_m = x / 10;
            int y_m = y / 10;

            var newValue = new Cell();
            newValue.IsConst = false;
            var values = Matrix.Where(m => m.Item1 == area).Select(m => m.values).FirstOrDefault();
            values[x_m,y_m] = newValue;
        }

        public Cell[,] InitMatrix(Cell[,] cells)
        {
            for (int i = 0; i < 60; i++)
                for (int j = 0; j < 60; j++)
                    cells[i, j] = new Cell();
            return cells;
        }

        public static void RecalculateMatrix(object area)
        {
            while (true)
            {
                Thread.Sleep(100);
                var _area = (Area)area;
                var matrix = Matrix.Where(m => m.Item1 == _area).Select(m => m.values).FirstOrDefault();
                bool isAnyConst = false;
                for (int i = 0; i < 60; i++)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        if (matrix[i, j].IsConst)
                            isAnyConst = true;
                    }
                }
                if (isAnyConst)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 60; j++)
                        {
                            if (matrix[i, j].IsConst)
                            {
                                for (int k = 0; k < 60; k++)
                                {
                                    for (int z = 0; z < 60; z++)
                                    {
                                        if (matrix[k, z].value < matrix[i, j].value)
                                        {
                                            matrix[k, z].value += Math.Exp(-Math.Sqrt(Math.Abs(k - i) ^ 2 + Math.Abs(z - j) ^ 2)) * matrix[i, j].value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else
                {
                    double avg = 0;
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 60; j++)
                        {
                            avg += matrix[i, j].value;
                        }
                    }
                    avg /= matrix.Length;
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 60; j++)
                        {
                            if (matrix[i, j].value > avg && matrix[i, j].value > 0)
                                matrix[i, j].value -= avg / 60;
                        }
                    }
                }
            }
        }
    }
}
