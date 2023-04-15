using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Lambertian
    {
        private String _name;
        private Vector _color;

        public string Name
        {
            get { return _name; }
            set
            {
                value = value.Trim();

                _name = value;
            }
        }

        public Vector Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
