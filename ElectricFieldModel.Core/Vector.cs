using System;

namespace ElectricFieldModel.Core
{
    public struct Coord3d
    {
        public Coord3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double[] AsArray => new double[] { X, Y, Z };

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }
    }

    public struct Vector
    {
        public static Vector Create(Coord3d start, Coord3d end)
        {
            return new Vector
            {
                start = start,
                end = end,
                position = new Coord3d(end.X - start.X, end.Y - start.Y, end.Z - start.Z),
            };
        }

        public static Vector Create(double startX, double startY, double startZ, double endX, double endY, double endZ)
        {
            return new Vector
            {
                start = new Coord3d(startX, startY, startZ),
                end = new Coord3d(endX, endY, endZ),
                position = new Coord3d(endX - startX, endY - startY, endZ - startZ),
            };
        }

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="number">Множитель</param>
        /// <returns></returns>
        public static Vector operator *(Vector vect, double number)
        {
            var newVector = new Vector();

            newVector.start = vect.start;
            newVector.position.X = vect.position.X * number;
            newVector.position.Y = vect.position.Y * number;
            newVector.position.Z = vect.position.Z * number;

            newVector.end.X = newVector.start.X + newVector.position.X;
            newVector.end.Y = newVector.start.Y + newVector.position.Y;
            newVector.end.Z = newVector.start.Z + newVector.position.Z;

            return newVector;
        }

        /// <summary>
        /// Сложение двух векторов по правилу параллелограмма
        /// </summary>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return Create(a.start, new Coord3d(a.end.X + b.end.X, a.end.Y + b.end.Y, a.end.Z + b.end.Z));
        }

        /// <summary>
        /// Нормирование вектора
        /// </summary>
        public void Normalize()
        {
            var l = Length;

            position.X = position.X / l;
            position.Y = position.Y / l;
            position.Z = position.Z / l;

            end.X = start.X + position.X;
            end.Y = start.Y + position.Y;
            end.Z = start.Z + position.Z;
        }

        /// <summary>
        /// Параллельный перенос вектора
        /// </summary>
        /// <param name="newCoord">Координаты начала</param>
        public void Move(Coord3d newCoord)
        {
            start = newCoord;

            end.X = start.X + end.X;
            end.Y = start.Y + end.Y;
            end.Z = start.Z + end.Z;
        }

        public double Length
        {
            get => Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.Z - start.Z, 2));
        }

        public Coord3d GetStartCoord => start;

        public Coord3d GetEndCoord => end;

        private Coord3d start, end;
        private Coord3d position;
    }
}
