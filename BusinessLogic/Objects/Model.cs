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
        private User _owner;
        public Model() { }

        public Model(string name, Sphere shape, Lambertian color, User owner)
        {
            Name = name;
            ModelShape = shape;
            ModelColor = color;
            Owner = owner;
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
            return this.Name == ((Model)other).Name;
        }
    }
}
