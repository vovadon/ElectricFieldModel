using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricFieldModel.Core
{
    public class Field
    {
        public Field(Coord3d downLeft, Coord3d upRight)
        {
            chargeList = new List<Charge>();

            this.downLeft = downLeft;
            this.upRight = upRight;
        }

        public void AddCharges(params Charge[] charges)
        {
            chargeList.AddRange(charges);
        }

        private Vector DetermineDirection(Coord3d point)
        {
            var length = chargeList.Count - 1;
            var tensionVectors = new Vector[length];

            var result = chargeList.First().GetTensionVector(point);

            for (int i = 0; i < length; i++)
            {
                tensionVectors[i] = chargeList[i + 1].GetTensionVector(point);

                result = result + tensionVectors[i];
            }
            return result;
        }

        private bool HasFinishReached(Coord3d point)
        {
            var negativeCharges = chargeList.Where(charge => charge.GetValue < 0d);

            foreach (var crg in negativeCharges)
            {
                double temp = Math.Pow(crg.GetPosition.X - point.X, 2) + Math.Pow(crg.GetPosition.Y - point.Y, 2) + Math.Pow(crg.GetPosition.Z - point.Z, 2);

                if (temp < crg.GetRadius * crg.GetRadius)
                    return true;
            }

            return false;
        }

        private bool Stop(Coord3d point)
        {
            if (point.X > upRight.X || point.X < downLeft.X || point.Y > upRight.Y || point.Y < downLeft.Y || point.Z > upRight.Z || point.Z < downLeft.Z)
                return true;
            else
                return false;
        }

        public void DrawLines(Charge crg, double step, int polygonCount, Action<double[]> SetNextPoint)
        {
            foreach (var vertex in crg.FillPoints(polygonCount))
            { 
                var coord = vertex;

                while (!Stop(coord) && !HasFinishReached(coord))
                {
                    var resultTension = DetermineDirection(coord);

                    resultTension.Normalize();
                    coord = resultTension.GetEndCoord;

                    SetNextPoint(resultTension.GetStartCoord.AsArray);
                    SetNextPoint(resultTension.GetEndCoord.AsArray);
                }
            }
        }

        public Charge[] GetChargeArray => chargeList.ToArray();

        private Coord3d downLeft, upRight;
        private readonly List<Charge> chargeList;
    }
}
