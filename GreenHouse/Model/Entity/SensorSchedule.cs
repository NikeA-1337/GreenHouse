using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class SensorSchedule
    {
        public double OptimalValue { get; set; }
        public double MaxDeviation { get; set; }
        public Time SensorStartTime { get; set; }
        public Time SensorEndTime { get; set; }
    }
}
