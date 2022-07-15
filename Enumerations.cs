namespace Bev.IO.JcampDx
{
    public enum DataType
    {
        Unknown,
        InfraredSpectrum,
        UvVisSpectrum,  // this is not standardized!
        RamanSpectrum,
        InfraredPeakTable,
        InfraredInterferogram,
        InfraredTransformedSpectrum
    }

    public enum SpectralSpacing
    {
        Unknown,
        FixedSpacing,   // ##XYDATA= (X++(Y..Y))
        VariableSpacing // ##XYPOINTS= (XY..XY)
    }
}
