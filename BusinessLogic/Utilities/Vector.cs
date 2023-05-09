using System;

namespace BusinessLogic
{
    public class Vector
    {
        private const double tolerance = 0.0001;
        public Vector()
        { }

        public Vector(double x, double y, double z)
        {
            FirstValue = x;
            SecondValue = y;
            ThirdValue = z;
        }
        public Vector(int x, int y, int z)
        {
            FirstValue = x;
            SecondValue = y;
            ThirdValue = z;
        }

        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
        public double ThirdValue { get; set; }

        public override string ToString()
        {
            return $"({FirstValue} ; {SecondValue} ; {ThirdValue})";
        }
        public override bool Equals(object other)
        {
            Vector otherVector = (Vector)other;

            bool evalFst = Math.Abs(FirstValue - otherVector.FirstValue) < tolerance;
            bool evalSnd = Math.Abs(SecondValue - otherVector.SecondValue) < tolerance;
            bool evalThrd = Math.Abs(ThirdValue - otherVector.ThirdValue) < tolerance;

            return evalFst && evalSnd && evalThrd;
        }

        public Vector Add(Vector other)
        {
            return new Vector(FirstValue + other.FirstValue, SecondValue + other.SecondValue, ThirdValue + other.ThirdValue);
        }

        public Vector Subtract(Vector other)
        {
            return new Vector(FirstValue - other.FirstValue, SecondValue - other.SecondValue, ThirdValue - other.ThirdValue);
        }

        public Vector Multiply(double value)
        {
            return new Vector(FirstValue * value, SecondValue * value, ThirdValue * value);
        }

        public Vector Divide(double value)
        {
            return new Vector(FirstValue / value, SecondValue / value, ThirdValue / value);
        }

        public void AddTo(Vector other)
        {
            FirstValue += other.FirstValue;
            SecondValue += other.SecondValue;
            ThirdValue += other.ThirdValue;
        }

        public void SubtractFrom(Vector other)
        {
            FirstValue -= other.FirstValue;
            SecondValue -= other.SecondValue;
            ThirdValue -= other.ThirdValue;
        }

        public void ScaleUpBy(int iCount)
        {
            FirstValue *= iCount;
            SecondValue *= iCount;
            ThirdValue *= iCount;
        }

        public void ScaleDownBy(int iCount)
        {
            FirstValue /= iCount;
            SecondValue /= iCount;
            ThirdValue /= iCount;
        }

        public double SquaredLength()
        {
            return FirstValue * FirstValue + SecondValue * SecondValue + ThirdValue * ThirdValue;
        }

        public double Length()
        {
            return Math.Sqrt(SquaredLength());
        }
        public Vector GetUnit()
        {
            double length = Length();
            if (length == 0)
            {
                return new Vector(FirstValue, SecondValue, ThirdValue);
            }
            else
            {
                return Divide(length);
            }
        }

        public double Dot(Vector other)
        {
            return FirstValue * other.FirstValue + SecondValue * other.SecondValue + ThirdValue * other.ThirdValue;
        }

        public Vector Cross(Vector other)
        {
            double x = SecondValue * other.ThirdValue - ThirdValue * other.SecondValue;
            double y = ThirdValue * other.FirstValue - FirstValue * other.ThirdValue;
            double z = FirstValue * other.SecondValue - SecondValue * other.FirstValue;
            return new Vector(x, y, z);
        }

        public static Vector GetRandomInUnitSphere()
        {
            Vector vector;
            do
            {
                Vector vectorTemp = new Vector(Engine.random.NextDouble(), Engine.random.NextDouble(), Engine.random.NextDouble());
                Vector unitVector = new Vector(1, 1, 1);
                vector = vectorTemp.Multiply(2).Subtract(unitVector);
            } while (vector.SquaredLength() >= 1);

            return vector;
        }
    }
}
