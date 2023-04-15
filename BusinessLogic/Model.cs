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
        public String Name { 
            get { return _name; } 
            set { _name = value; } 
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
    }
}
