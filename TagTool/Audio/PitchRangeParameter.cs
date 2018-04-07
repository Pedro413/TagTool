﻿using TagTool.Cache;
using TagTool.Common;
using TagTool.Serialization;


namespace TagTool.Audio
{
    [TagStructure(Size = 0xE, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Size = 0x10, MinVersion = CacheVersion.Halo3ODST)]
    public class PitchRangeParameter
    {
        public short NaturalPitch;

        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public short Unknown;

        public Bounds<short> BendBounds;
        public Bounds<short> MaxGainPitchBounds;
        public Bounds<short> UnknownBounds;
    }
}