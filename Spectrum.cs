using At.Matus.StatisticPod;
using System.Collections.Generic;
using System.Linq;

namespace Bev.IO.JcampDx
{
    public class Spectrum
    {
        private List<SpectralPoint> spectrum = new List<SpectralPoint>();
        private StatisticPod xStat = new StatisticPod();
        private StatisticPod yStat = new StatisticPod();

        public int Length => spectrum.Count;
        public double FirstX => spectrum.First().X;
        public double LastX => spectrum.Last().X;
        public double FirstY => spectrum.First().Y;
        public double LastY => spectrum.Last().Y;
        public double MaxX => xStat.MaximumValue;
        public double MinX => xStat.MinimumValue;
        public double MaxY => yStat.MaximumValue;
        public double MinY => yStat.MinimumValue;

        public void AddValue(SpectralPoint value)
        {
            spectrum.Add(value);
            xStat.Update(value.X);
            yStat.Update(value.Y);
            spectrum.Sort();
        }

        public void AddValue(double xValue, double yValue) => AddValue(new SpectralPoint(xValue, yValue));

        public SpectralPoint[] GetSpectrum()
        {
            spectrum.Sort();
            return spectrum.ToArray();
        }
            
    }
}
