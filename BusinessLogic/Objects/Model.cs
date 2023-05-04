using BusinessLogic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Model
    {
        private string _name;
        private Sphere _shape;
        private Lambertian _color;

        public Model() { }

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

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public Sphere ModelShape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public Lambertian ModelColor
        {
            get { return _color; }
            set { _color = value; }
        }
     
        public override bool Equals(object other)
        {
            bool nameEqual = this.Name == ((Model)other).Name;
            bool shapeEqual = this.ModelShape == ((Model)other).ModelShape;
            bool colorEqual = this.ModelColor == ((Model)other).ModelColor;

            return nameEqual && shapeEqual && colorEqual;
        }
    }
}
