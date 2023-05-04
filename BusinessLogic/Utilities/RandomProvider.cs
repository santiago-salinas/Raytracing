using System;

namespace BusinessLogic
{
    public class RandomProvider : Random
    {
        public override double NextDouble()
        {
            return 0.5;
        }
    }
}
