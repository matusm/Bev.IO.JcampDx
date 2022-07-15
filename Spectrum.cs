using At.Matus.StatisticPod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bev.IO.JcampDx
{
    public class Spectrum
    {
        private const double epsilon = 0.0001;
        private List<SpectralPoint> spectrum = new List<SpectralPoint>();
        private StatisticPod xStat = new StatisticPod();
        private StatisticPod yStat = new StatisticPod();

        public SpectralSpacing AbscissaType => EstimateSpacingType();
        public int Length => spectrum.Count;
        public double FirstX => spectrum.First().X;
        public double LastX => spectrum.Last().X;
        public double FirstY => spectrum.First().Y;
        public double LastY => spectrum.Last().Y;
        public double MaxX => xStat.MaximumValue;
        public double MinX => xStat.MinimumValue;
        public double MaxY => yStat.MaximumValue;
        public double MinY => yStat.MinimumValue;
        public double DeltaX => (LastX - FirstX) / (Length - 1); // only usefull for equidistant data points

        public void AddValue(SpectralPoint value)
        {
            spectrum.Add(value);
            xStat.Update(value.X);
            yStat.Update(value.Y);
            spectrum.Sort();
        }

        public void AddValue(double xValue, double yValue) => AddValue(new SpectralPoint(xValue, yValue));

        public SpectralPoint[] GetSpectrum() => spectrum.ToArray();

        private SpectralSpacing EstimateSpacingType() 
        {
            SpectralPoint[] spec = GetSpectrum();
            if (spec.Length < 3)
                return SpectralSpacing.Unknown;
            var lambdaDiff = new StatisticPod();
            for (int i = 0; i < spec.Length-1; i++)
            {
                lambdaDiff.Update(spec[i + 1].X - spec[i].X);
            }
            double rangeOfSpacings = Math.Abs(lambdaDiff.Range);
            if (rangeOfSpacings < epsilon)
                return SpectralSpacing.FixedSpacing;
            return SpectralSpacing.VariableSpacing; 
        }

            
    }
}
