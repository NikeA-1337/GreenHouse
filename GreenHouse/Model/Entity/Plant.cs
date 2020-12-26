using System.Collections.Generic;

namespace Model.Entity
{
    public class Plant
    {
        public string Name { get; set; }
        public List<DaySchedule> GrowingPlan { get; set; }
    }
}
