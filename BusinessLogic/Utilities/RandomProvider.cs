using System;

namespace BusinessLogic
{
    public class RandomProvider : Random
    {
        private const double selectedValue = 0.5;

        public override double NextDouble()
        {
            return selectedValue;
        }
    }
}
