using System;
using System.Collections.Generic;
using Model;
using Model.Entity;

namespace DAL.Repository
{
    public class PlantRepository : IRepository<Plant>
    {
        List<Plant> _data = new List<Plant>();
        private int _end_index = 0;

        public int Add(Plant obj)
        {
            _data.Add(obj);
            _end_index++;
            return _end_index;
        }

        public List<Plant> GetAll()
        {
            return _data;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Plant obj)
        {
            throw new NotImplementedException();
        }
    }
}
