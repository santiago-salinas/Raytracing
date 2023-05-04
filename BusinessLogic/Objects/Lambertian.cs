using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;

namespace BusinessLogic
{
    public class Lambertian
    {
        private string _name;
        private Color _color;

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

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

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
