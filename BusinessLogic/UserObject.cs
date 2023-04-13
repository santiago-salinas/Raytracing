using System;

namespace BusinessLogic
{
    public class UserObject
    {
        public UserObject()
        {
        }

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

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }


        public bool Equals(Sphere other)
        {
            return this.Name == other.Name;
        }
    }
}
