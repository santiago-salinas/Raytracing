using System;

namespace BusinessLogic
{
    public class Lambertian
    {
        private string _name;

        public Lambertian() { }
        
        public Lambertian(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                value = value.Trim();
                CheckIfStringNull(value);
                _name = value;
            }
        }

        public Color Color {get; set; }
        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public override bool Equals(object other)
        {
            bool namesEqual = this.Name == ((Lambertian)other).Name;
            bool colorEqual = this.Color == ((Lambertian)other).Color;
            return namesEqual && colorEqual; 
        }
    }
}
