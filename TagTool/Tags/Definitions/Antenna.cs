using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "antenna", Tag = "ant!", Size = 0x4C, MaxVersion = CacheVersion.Halo3ODST)]
    [TagStructure(Name = "antenna", Tag = "ant!", Size = 0x50, MinVersion = CacheVersion.HaloOnline106708)]
    public class Antenna : TagStructure
	{
        public StringId AttachmentMarkerName;
        public CachedTagInstance Bitmaps;
        public CachedTagInstance Physics;
        public float SpringStrengthCoefficient;
        public float FalloffPixels;
        public float CutoffPixels;
        public float PointOfBend;
        public float StartingBend;
        public float EndingBend;
        public float RuntimeTotalLength;
        public List<Vertex> Vertices;

        [TagField(Flags = Padding, Length = 4, MinVersion = CacheVersion.HaloOnline106708)]
        public byte[] Unused;

        [TagStructure(Size = 0x40)]
        public class Vertex : TagStructure
		{
            public RealEulerAngles2d Angles;
            public float Length;
            public short SequenceIndex;
            [TagField(Flags = Padding, Length = 2)]
            public byte[] Unused;
            public RealArgbColor Color;
            public RealArgbColor LodColor;
            public float HermiteT;
            public RealVector3d VectorToNext;
        }
    }
}