using System;
using System.Collections.Generic;
using Model;
using Model.Entity;

namespace DAL.Repository
{
    public class ImageRepository : IRepository<UIElement>
    {
        private static List<UIElement> _data = new List<UIElement>();
        private static int _end_index = 0;
        public int Add(UIElement obj)
        {
            _data.Add(obj);
            _end_index++;
            return _end_index;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UIElement obj)
        {
            throw new NotImplementedException();
        }

        List<UIElement> IRepository<UIElement>.GetAll()
        {
            List<UIElement> list = new List<UIElement>();
            foreach (var item in _data)
                list.Add(new UIElement(item));
            return list;
        }

        public void InitializeData()
        { 
        }
    }
}
