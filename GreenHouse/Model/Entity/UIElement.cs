using System.Drawing;
using static EnvironmentModulation.Environment;

namespace Model.Entity
{
    public enum DeviceType
    {
        Device,
        ActiveSensor,
        PasssiveSensor
    }
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Size
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class UIElement : EntityBase
    {
        public string ElementName { get; set; }
        public string FilePath { get; set; }
        public Position Position { get; set; }
        public Size Size{ get; set; }
        public DeviceType DeviceType { get; set; }
        public Area Area { get; set; }
        public Bitmap Image { get; set; }
        public string CurrentState { get; set; }

        public UIElement(string elementName,DeviceType deviceType,Area area,string filePath, int x, int y)
        {
            ElementName = elementName;
            Area = area;
            DeviceType = deviceType;
            FilePath = filePath;
            Position = new Position();
            Position.x = x;
            Position.y = y;
            CurrentState = string.Empty;
            Image = new Bitmap(filePath);
        }

        public UIElement(UIElement obj)
        {
            ElementName = obj.ElementName;
            FilePath = obj.FilePath;
            Position = new Position();
            Position.x = obj.Position.x;
            Position.y = obj.Position.y;
            //Size = new Size();
            //Size.x = obj.Size.x;
            //Size.y = obj.Size.y;
            Image = obj.Image;
            CurrentState = obj.CurrentState;
            DeviceType = obj.DeviceType;
        }
    }
}
