using System;

namespace BusinessLogic
{
    public class Model
    {
        private string _name;

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

        public Sphere ModelShape { get; set; }

        public Lambertian ModelColor { get; set; }

        public override bool Equals(object other)
        {
            bool nameEqual = this.Name == ((Model)other).Name;
            bool shapeEqual = this.ModelShape == ((Model)other).ModelShape;
            bool colorEqual = this.ModelColor == ((Model)other).ModelColor;

            return nameEqual && shapeEqual && colorEqual;
        }
    }
}
