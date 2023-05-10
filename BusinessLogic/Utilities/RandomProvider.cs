using System;

namespace BusinessLogic
{
    public class RandomProvider : Random
    {
        private const double _selectedValue = 0.5;

        public override double NextDouble()
        {
            return _selectedValue;
        }
    }
}
