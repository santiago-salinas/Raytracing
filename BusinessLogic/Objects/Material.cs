using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class Material
    {
        private string _name;

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

        public User Owner { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public Color Preview { get; set; }

        abstract public Ray GetBouncedRay(Ray rayin, HitRecord hitRecord);

        abstract public HitRecord AddToHit(HitRecord hitRecord);

        

        abstract public override bool Equals(object other);
    }
}