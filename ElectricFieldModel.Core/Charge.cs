using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricFieldModel.Core
{
    public struct Charge
    {
        public Charge(Coord3d position, double radius, double value)
        {
            this.position = position;
            this.radius = radius;
            this.value = value;
        }

        /// <summary>
        /// Расставляет точки на сфере и возвращает массив координат этих точек
        /// </summary>
        /// <param name="pointCount"></param>
        /// <returns></returns>
        public Coord3d[] FillPoints(int pointCount)
        {
            double x, y, z;
            double pi_divideBy_pCount = Math.PI / pointCount;
            List<Coord3d> vectors = new List<Coord3d>();

            for (int iy = 0; iy < pointCount; iy++)
            {
                for (int ix = 0; ix <= pointCount; ix++)
                {
                    x = radius * Math.Sin(iy * pi_divideBy_pCount) * Math.Cos(2 * ix * pi_divideBy_pCount);
                    y = radius * Math.Sin(iy * pi_divideBy_pCount) * Math.Sin(2 * ix * pi_divideBy_pCount);
                    z = radius * Math.Cos(iy * pi_divideBy_pCount);

                    vectors.Add(new Coord3d(x, y, z));
                }
            }
            return vectors.ToArray();
        }

        public Vector GetTensionVector(Coord3d point)
        {
            var tension = value > 0 ? Vector.Create(position, point) : Vector.Create(point, position);
            var distance = tension.Length;

            tension.Normalize();
            tension.Move(point);
            tension = tension * (e * Math.Abs(value) / (distance * distance));

            return tension;
        }

        public Coord3d GetPosition => position;

        public double GetValue => value;

        public double GetRadius => radius;

        private Coord3d position;
        private double radius, value;
        private const double e = 1 / (4 * Math.PI * 8.85E-12);
    }
}
