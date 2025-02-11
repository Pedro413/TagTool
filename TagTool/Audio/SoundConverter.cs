﻿using System;
using System.Diagnostics;
using System.IO;
using TagTool.Audio.Converter;
using TagTool.Cache;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions;

namespace TagTool.Audio
{
    public static class SoundConverter
    {
        private static readonly string BaseFileName = "temp";
        private static readonly string XMAFile = BaseFileName + ".xma";
        private static readonly string WAVFile = BaseFileName + ".wav";
        private static readonly string MP3File = BaseFileName + ".mp3";
        private static readonly string FSBFile = BaseFileName + ".fsb";
        //file names for multi channel files generated by towav
        private static readonly string WAV1FlUnk = BaseFileName + " 1 Fl Unk.wav";
        private static readonly string WAV2BlUnk = BaseFileName + " 2 Bl Unk.wav";

        private static readonly string WAV2CUnk = BaseFileName + " 2 C Unk.wav";
        private static readonly string WAV3BlUnk = BaseFileName + " 3 Bl Unk.wav";

        public static BlamSound ConvertGen3Sound(CacheFile cache, SoundCacheFileGestalt soundGestalt, Sound sound, int pitchRangeIndex, int permutationIndex, byte[] data)
        {
            ClearFiles();
            BlamSound blamSound = GetXMA(cache, soundGestalt, sound, pitchRangeIndex, permutationIndex, data);

            var loop = sound.Flags.HasFlag(Sound.FlagsValue.LoopingSound);
            var channelCount = Encoding.GetChannelCount(blamSound.Encoding);
            var sampleRate = blamSound.SampleRate.GetSampleRateHz();

            WriteXMAFile(blamSound);

            if (channelCount > 2)
            {
                // channelCount is 4 or 6, ignore looping
                ConvertToWAV(XMAFile, false);
                byte[] originalWAVdata = File.ReadAllBytes(WAVFile);
                byte[] truncatedWAVdata = TruncateWAVFile(originalWAVdata, sampleRate, channelCount, 0x4E);
                blamSound.UpdateFormat(Compression.PCM, truncatedWAVdata);
                WriteWAVFile(blamSound);
                ConvertToMP3(WAVFile);
                LoadMP3Data(blamSound);
            }
            else if (!loop)
            {
                // not looping stereo or mono
                ConvertToWAV(XMAFile, true);
                blamSound.UpdateFormat(Compression.PCM, LoadWAVData(WAVFile, -1, false));
                WriteWAVFile(blamSound);
                ConvertToMP3(WAVFile);
                LoadMP3Data(blamSound);
            }
            else
            {
                ConvertToWAV(XMAFile, true);
                blamSound.UpdateFormat(Compression.PCM, LoadWAVData(WAVFile, -1, false));
                WriteWAVFile(blamSound);
                ConvertWAVToMP3Looping(WAVFile);
                blamSound.UpdateFormat(Compression.MP3, File.ReadAllBytes(MP3File));
            }
            ClearFiles();
            return blamSound;
        }

        public static byte[] GetXMAData(CacheFile cache, DatumIndex handle, int size)
        {
            return cache.GetSoundRaw(handle, size);
        }

        public static BlamSound GetXMA(CacheFile cache, SoundCacheFileGestalt soundGestalt, Sound sound, int pitchRangeIndex, int permutationIndex, byte[] data)
        {
            if (cache.ResourceLayoutTable == null || cache.ResourceGestalt == null)
                cache.LoadResourceTags();

            int pitchRangeGestaltIndex = sound.SoundReference.PitchRangeIndex + pitchRangeIndex;
            int permutationGestaltIndex = soundGestalt.PitchRanges[pitchRangeGestaltIndex].FirstPermutationIndex + permutationIndex;

            var permutationSize = soundGestalt.GetPermutationSize(permutationGestaltIndex);
            var permutationOffset = soundGestalt.GetPermutationOffset(permutationGestaltIndex);
            byte[] permutationData = new byte[permutationSize];
            Array.Copy(data, permutationOffset, permutationData, 0, permutationSize);

            return new BlamSound(sound, permutationGestaltIndex, permutationData, cache.Version, soundGestalt);
        }

        private static void ConvertToWAV(string XMAFileName, bool useTowav = true)
        {
            if (useTowav)
            {
                ProcessStartInfo info = new ProcessStartInfo(@"Tools\towav.exe")
                {
                    Arguments = " " + XMAFileName,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardError = false,
                    RedirectStandardOutput = false,
                    RedirectStandardInput = false
                };
                Process towav = Process.Start(info);
                towav.WaitForExit();
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo(@"Tools\ffmpeg.exe")
                {
                    Arguments = "-i " + XMAFileName + " -q:a 0 " +WAVFile,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardError = false,
                    RedirectStandardOutput = false,
                    RedirectStandardInput = false
                };
                Process ffmpeg = Process.Start(info);
                ffmpeg.WaitForExit();
            }
            
        }

        private static void ConvertToMP3(string WAVFileName)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"Tools\ffmpeg.exe")
            {
                Arguments = "-i " + WAVFileName + " -q:a 0 " + MP3File,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false
            };
            Process ffmpeg = Process.Start(info);
            ffmpeg.WaitForExit();
        }

        private static bool LoadANdMergeWAV(BlamSound blamSound)
        {
            uint length = (uint)(2 * blamSound.SampleCount * Encoding.GetChannelCount(blamSound.Encoding));

            byte[] WAVFLR = null;
            //byte[] WAVRLR = null;
            //byte[] WAVCCL = null;
            switch (Encoding.GetChannelCount(blamSound.Encoding))
            {
                case 1:
                case 2:
                    byte[] data = LoadWAVData(WAVFile, (int)length, false);
                    blamSound.UpdateFormat(Compression.PCM, data);
                    uint newSampleCount = (uint)(data.Length / (Encoding.GetChannelCount(blamSound.Encoding) * 2));
                    blamSound.SampleCount = newSampleCount;
                    break;
                case 4:
                    WAVFLR = LoadWAVData(WAV1FlUnk, (int)length / 2);
                    //WAVRLR = LoadWAVData(WAV2BlUnk, (int)length / 2);
                    blamSound.UpdateFormat(Compression.PCM, WAVFLR); //MergeChannels(length, WAVFLR, WAVRLR)
                    blamSound.Encoding = EncodingValue.Stereo;
                    break;
                case 6:
                    WAVFLR = LoadWAVData(WAV1FlUnk, (int)length / 3);
                    //WAVCCL = LoadWAVData(WAV2CUnk, (int)length / 3);
                    //WAVRLR = LoadWAVData(WAV3BlUnk, (int)length / 3);
                    blamSound.UpdateFormat(Compression.PCM, WAVFLR); //MergeChannels(length, WAVFLR, WAVCCL, WAVRLR)
                    blamSound.Encoding = EncodingValue.Stereo;
                    break;
            }
            return true;
        }
        
        private static void LoadMP3Data(BlamSound blamSound)
        {
            byte[] data = File.ReadAllBytes(MP3File);
            var dataLength = data.Length - 0x51;
            byte[] result = new byte[dataLength];
            // remove ID3 header from mp3 file
            Array.Copy(data, 0x51, result, 0, dataLength);
            blamSound.UpdateFormat(Compression.MP3, result);
        }

        private static void ConvertWAVToMP3Looping(string WAVFileName)
        {
            // Assumes that wavFileName and mp3FileName have the same name but different extensions.
            ProcessStartInfo info = new ProcessStartInfo(@"Tools\mp3loop.exe")
            {
                Arguments = WAVFileName,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false
            };
            Process mp3loop = Process.Start(info);
            mp3loop.WaitForExit();
        }

        private static void CreateFSB4(BlamSound blamSound)
        {
            blamSound.UpdateFormat(Compression.FSB4, null);
        }

        private static void WriteXMAFile(BlamSound blamSound)
        {
            using (EndianWriter output = new EndianWriter(new FileStream(XMAFile, FileMode.Create, FileAccess.Write, FileShare.None), EndianFormat.BigEndian))
            {
                XMAFile XMAfile = new XMAFile(blamSound);
                XMAfile.Write(output);
            }
        }

        private static void WriteWAVFile(BlamSound blamSound)
        {
            using (EndianWriter output = new EndianWriter(new FileStream(WAVFile, FileMode.Create, FileAccess.Write, FileShare.None), EndianFormat.BigEndian))
            {
                WAVFile WAVfile = new WAVFile(blamSound);
                WAVfile.Write(output);
            }
        }

        private static void WriteFSBFile(BlamSound blamSound)
        {
            using (EndianWriter output = new EndianWriter(new FileStream(FSBFile, FileMode.Create, FileAccess.Write, FileShare.None), EndianFormat.BigEndian))
            {
                FSB4File FSB4File = new FSB4File(blamSound);
                FSB4File.Write(output);
            }
        }

        private static void ClearFiles()
        {
            DeleteFile(XMAFile);
            DeleteFile(WAVFile);
            DeleteFile(MP3File);
            DeleteFile(FSBFile);
            DeleteFile(WAV1FlUnk);
            DeleteFile(WAV2BlUnk);
            DeleteFile(WAV2CUnk);
            DeleteFile(WAV3BlUnk);
        }

        private static void DeleteFile(string name)
        {
            if (File.Exists(name))
                File.Delete(name);
        }

        private static byte[] TruncateWAVFile(byte[] data, int sampleRate, int channelCount, int additionalOffset = 0)
        {
            var bytesPerSample = 2;         //16 bit PCM
            int startOffset = (0x240 * channelCount * bytesPerSample);                       // Offset from index 0 
            int endOffset = (0xBE * channelCount * bytesPerSample);                                           // Offset from index data.Length -1
            if (channelCount == 1)
                endOffset = 0;

            int size = data.Length - startOffset - endOffset - additionalOffset;
            byte[] result = new byte[size];
            Array.Copy(data, startOffset + additionalOffset, result, 0, size);
            return result;
        }


        private static byte[] LoadWAVData(string name, int length, bool matchLength=true)
        {
            var fileLength = new FileInfo(name).Length - 0x2E;
            byte[] result = null;
            if (matchLength)
            {
                if (fileLength > length)
                    fileLength = length;

                result = new byte[length];
                byte[] data = File.ReadAllBytes(name);
                // length-fileLength != 0 when merging multi channel files, otherwise they are equal and fileLengtth - 0x2E is the actual length of the wav data.
                Array.Copy(data, 0x2E, result, length - fileLength, fileLength);
            }
            else
            {
                byte[] data = File.ReadAllBytes(name);
                result = new byte[fileLength];
                Array.Copy(data, 0x2E, result, 0, fileLength);
            }
            return result;
        }

        private static byte[] MergeChannels(uint length, byte[] front, byte[] rear)
        {
            byte[] result = new byte[length];
            // 2 bytes per channel, 4 channels. front first, rear second.
            for(int i = 0; i < length; i += 8)
            {
                result[i + 0] = front[i / 2 + 0];
                result[i + 1] = front[i / 2 + 1];
                result[i + 2] = front[i / 2 + 2];
                result[i + 3] = front[i / 2 + 3];
                result[i + 4] = rear[i / 2 + 0];
                result[i + 5] = rear[i / 2 + 1];
                result[i + 6] = rear[i / 2 + 2];
                result[i + 7] = rear[i / 2 + 3];
            }
            return result;
        }

        private static byte[] MergeChannels(uint length, byte[] front, byte[] center, byte[] rear)
        {
            byte[] result = new byte[length];
            // 2 bytes per channel, 6 channels. front first, center second, rear third.
            for (int i = 0; i < length; i += 12)
            {
                result[i + 0] = front[i / 3 + 0];
                result[i + 1] = front[i / 3 + 1];
                result[i + 2] = front[i / 3 + 2];
                result[i + 3] = front[i / 3 + 3];
                result[i + 4] = center[i / 3 + 0];
                result[i + 5] = center[i / 3 + 1];
                result[i + 6] = center[i / 3 + 2];
                result[i + 7] = center[i / 3 + 3];
                result[i + 8] = rear[i / 3 + 0];
                result[i + 9] = rear[i / 3 + 1];
                result[i + 10] = rear[i / 3 + 2];
                result[i + 11] = rear[i / 3 + 3];

            }
            return result;
        }
    }
}
