using System;

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
            bool namesEqual = this.Name == ((Lambertian)other).Name;
            bool ownerEqual = this.Owner == ((Lambertian)other).Owner;
            return namesEqual && ownerEqual;
        }

        public abstract HitRecord IsHitByRay(HitRecord hit);
    }
}
