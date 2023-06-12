namespace DataTransferObjects
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
