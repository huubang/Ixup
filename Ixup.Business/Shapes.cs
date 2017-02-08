using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ixup.Business
{
    public interface IShape
    {
        // We want to control the measures via constructors to limit the number of measures in certain shapes like triangles
        IEnumerable<double> Measures { get; }
        bool IsValidShape();
        double ComputeArea();
        double ComputePerimeter();
    }

    public class Triangle : IShape
    {
        public TriangleType Type { get; private set; }
        public IEnumerable<double> Measures { get; private set; }

        public Triangle(double edge1, double edge2, double edge3)
        {
            var measures = new List<double> { edge1, edge2, edge3 };

            if (measures.Any(m => m <= 0) || measures.Any(m => 2 * m >= measures.Sum()))
            {
                throw new InvalidTriangleException(measures);
            }

            this.Measures = measures;

            this.DetermineType();
        }

        public bool IsValidShape()
        {
            return Measures.All(m => m > 0) && Measures.All(m => 2 * m < Measures.Sum());
        }

        private void DetermineType()
        {
            var distinctCount = Measures.Distinct().Count();

            switch (distinctCount)
            {
                case 1:
                    Type = TriangleType.Equilateral;
                    break;

                case 2:
                    Type = TriangleType.Isosceles;
                    break;

                case 3:
                    Type = TriangleType.Scalene;
                    break;

                default:
                    throw new InvalidTriangleException(Measures);
            }            
        }

        public double ComputeArea()
        {
            double halfP = Measures.Sum() / 2d;

            var herons = Measures.ToList();
            herons.Insert(0, halfP);

            return Math.Round(Math.Sqrt(herons.Aggregate((r, e) => r * (halfP - e))), 2);
        }

        public double ComputePerimeter()
        {
            return Measures.Sum();
        }
    }

    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException(string message)
            : base(message)
        {
        }

        public InvalidTriangleException(IEnumerable<double> measures)
            : base($"Invalid triangles: {string.Join(", ", measures)}")
        {
        }
    }

    public enum TriangleType
    {
        Equilateral,
        Isosceles,
        Scalene
    }
}
