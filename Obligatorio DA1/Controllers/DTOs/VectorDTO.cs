using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DTOs
{
    public class VectorDTO
    {
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public double ThirdValue { get; set; }

        public VectorDTO() { }

        public VectorDTO(double firstValue, double secondValue, double thirdValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
            ThirdValue = thirdValue;
        }
    }
}
