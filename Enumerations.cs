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

    public enum TabularSpectralDataType
    {
        Unknown,
        EqualInterval,  // ##XYDATA= (X++(Y..Y))
        UnequalInterval // ##XYPOINTS= (XY..XY)
    }


}
