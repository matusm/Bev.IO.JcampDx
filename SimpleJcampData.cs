using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bev.IO.JcampDx
{
    public class SimpleJcampData
    {

        private const string dataLabelFlag = "##";
        private const string dataLabelTerminator = "= ";    // trailing space included
        private Spectrum spectrum;

        public string Title = string.Empty;
        public string DataType = string.Empty;
        public string Origin = string.Empty;
        public string Owner = string.Empty;
        public string SpectrometerSystem = string.Empty;
        public string InstrumentParameters = string.Empty;
        public string SampleDescription = string.Empty;
        public string Concentrations = string.Empty;
        public string SamplingProcedure = string.Empty;
        public string State = string.Empty;
        public string PathLength = string.Empty;
        public string Pressure = string.Empty;
        public string Temperature = string.Empty;
        public string DataProcessing = string.Empty;

        public string Xunits = string.Empty;
        public string Yunits = string.Empty;
        public string Xlabel = string.Empty;
        public string Ylabel = string.Empty;

        public DateTime MeasurementDate;
        
        public int Npoints;
        public double DeltaX = double.NaN;
        public double Xfactor = 1;
        public double Yfactor = 1;
        public double FirstX = double.NaN;
        public double LastX = double.NaN;
        public double FirstY = double.NaN;
        public double MaxX = double.NaN;
        public double MinX = double.NaN;
        public double MaxY = double.NaN;
        public double MinY = double.NaN;

        public SimpleJcampData()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public void SetSpectrum(Spectrum spectrum)
        {
            this.spectrum = spectrum;
            Npoints = spectrum.Length;
            FirstX = spectrum.FirstX;
            LastX = spectrum.LastX;
            FirstY = spectrum.FirstY;
            MaxX = spectrum.MaxX;
            MinX = spectrum.MinX;
            MaxY = spectrum.MaxX;
            MinY = spectrum.MinY;
        }

        public string GetDataRecords()
        {
            StringBuilder sb = new StringBuilder();
            AppendRecord("TITLE", Title);
            AppendRecord("JCAMP-DX", "4.24");
            AppendRecord("DATA TYPE", DataType);
            AppendRecord("SAMPLE DESCRIPTION", SampleDescription);
            AppendRecord("ORIGIN", Origin);
            AppendRecord("OWNER", Owner);
            AppendRecord("SPECTROMETER/DATA SYSTEM", SpectrometerSystem);
            AppendRecord("INSTRUMENT PARAMETERS", InstrumentParameters);
            AppendRecord("DATE", MeasurementDate.ToString("yy/MM/dd"));
            AppendRecord("TIME", MeasurementDate.ToString("HH:mm:ss"));
            AppendRecord("LONG DATE", MeasurementDate.ToString("yyyy/MM/dd HH:mm:ssK")); // TODO not 4.24 compliant!
            AppendRecord("XUNITS", Xunits);
            AppendRecord("YUNITS", Yunits);

            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("", "");
            AppendRecord("XYDATA", "(X++(Y..Y))");


            sb.AppendLine(LabeledDataRecord("END", string.Empty)); // cant use AppendRecord() here !
            return sb.ToString();

            void AppendRecord(string label, string value)
            {
                if (string.IsNullOrEmpty(value)) return;
                sb.AppendLine(LabeledDataRecord(label, value));
            }

        }

        private string LabeledDataRecord(string label, string value) => $"{dataLabelFlag}{label}{dataLabelTerminator}{value}";

        


    }
}
