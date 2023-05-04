using System;

namespace BusinessLogic
{
    public class Lambertian
    {
        private string _name;
        private Color _color;
        private User _owner;

        public Lambertian() { }

        public Lambertian(string name, Color color, User user)
        {
            Name = name;
            Color = color;
            Owner = user;
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

        public User Owner
        {
            get { return _owner; }
            set { _owner = value; }
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
