using System;
using BusinessLogic.Exceptions;
using BusinessLogic.Utilities;

namespace BusinessLogic.Objects
{
    public abstract class Material
    {
        private string _name;
        public abstract string Type { get;}
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

        public abstract Color Preview { get; }

        public string Owner { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new BusinessLogicException("Name cannot be empty");
            }
        }

        public abstract Ray GetBouncedRay(HitRecord hitRecord);

        public override bool Equals(object other)
        {
            bool namesEqual = this.Name == ((Material)other).Name;
            bool ownerEqual = this.Owner == ((Material)other).Owner;
            return namesEqual && ownerEqual;
        }

        public abstract HitRecord IsHitByRay(HitRecord hit);

        public override abstract string ToString();
    }
}
