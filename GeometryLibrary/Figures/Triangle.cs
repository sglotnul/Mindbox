using Geometry.Exceptions;

namespace Geometry
{
    public class Triangle : IFigure
    {
        void ValidateSide(double side, double sideSum)
        {
            if (side <= 0) throw new ValidationException($"side can not be negative");
            if (side >= sideSum) throw new ValidationException($"side can not be greater than the sum of the other two sides");
        }

        #region side properties
        double _side1 = -1, _side2 = -1, _side3 = -1;
        public double Side1 { 
            get => _side1;
            set
            {
                if (_side1 != -1) ValidateSide(value, Side2 + Side3);
                _side1 = value;
            }
        }
        public double Side2
        {
            get => _side2;
            set
            {
                if(_side2 != -1) ValidateSide(value, Side1 + Side3);
                _side2 = value;
            }
        }
        public double Side3
        {
            get => _side3;
            set
            {
                if (_side3 != -1) ValidateSide(value, Side2 + Side1);
                _side3 = value;
            }
        }
        #endregion

        public bool IsRight()
        {
            double[] sides = new double[3]
            {
                Side1,
                Side2,
                Side3
            };

            Array.Sort(sides);

            return Math.Pow(sides[2], 2) == Math.Pow(sides[1], 2) + Math.Pow(sides[0], 2);
        }

        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            ValidateSide(Side1, Side2 + Side3);
            ValidateSide(Side2, Side1 + Side3);
            ValidateSide(Side3, Side2 + Side1);
        }

        public double Area()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
    }
}