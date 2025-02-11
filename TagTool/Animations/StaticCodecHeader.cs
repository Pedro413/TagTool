﻿using TagTool.Tags;

/// <summary>
/// Thanks Grimdoomer! -Camden
/// </summary>

namespace TagTool.Animations
{
    [TagStructure(Size = 0x14)]
    public class StaticCodecHeader : AnimationCodecHeader
    {
        public int TranslationDataOffset;
        public int ScaleDataOffset;
        public int RotationFrameSize;
        public int TranslationFrameSize;
        public int ScaleFrameSize;
    }
}