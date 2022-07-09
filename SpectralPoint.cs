using System;

namespace Bev.IO.JcampDx
{
    public class SpectralPoint : IComparable<SpectralPoint>
    {
        public double X;
        public double Y;

        public SpectralPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public int CompareTo(SpectralPoint other) => X.CompareTo(other.X);

        public override string ToString() => $"[SpectralPoint: X={X}, Y={Y}]";
    }
}
