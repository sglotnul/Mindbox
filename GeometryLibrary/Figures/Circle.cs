using Geometry.Exceptions;

namespace Geometry
{
    public class Circle : IFigure
    {
        private double _radius;
        public double Radius { 
            get => _radius; 
            set 
            {
                if (value <= 0) throw new ValidationException("invalid radius value");
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}