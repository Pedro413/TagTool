using System;
using TagTool.Tags;

namespace TagTool.Cache
{
    public static class CacheVersionDetection
    {
        /// <summary>
        /// Detects the engine that a tags.dat was built for.
        /// </summary>
        /// <param name="cache">The cache file.</param>
        /// <param name="closestGuess">On return, the closest guess for the engine's version.</param>
        /// <returns>The engine version if it is known for sure, otherwise <see cref="CacheVersion.Unknown"/>.</returns>
        public static CacheVersion DetectFromTagCache(TagCache cache, out CacheVersion closestGuess)
        {
            return DetectFromTimestamp(cache.Timestamp, out closestGuess);
        }

        /// <summary>
        /// Detects the engine that a tags.dat was built for based on its timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="closestGuess">On return, the closest guess for the engine's version.</param>
        /// <returns>The engine version if the timestamp matched directly, otherwise <see cref="CacheVersion.Unknown"/>.</returns>
        public static CacheVersion DetectFromTimestamp(long timestamp, out CacheVersion closestGuess)
        {
            var index = Array.BinarySearch(VersionTimestamps, timestamp);
            if (index >= 0)
            {
                // Version matches a timestamp directly
                closestGuess = (CacheVersion)index;
                return closestGuess;
            }

            // Match the closest timestamp
            index = Math.Max(0, Math.Min(~index - 1, VersionTimestamps.Length - 1));
            closestGuess = (CacheVersion)index;
            return CacheVersion.Unknown;
        }

        /// <summary>
        /// Gets the timestamp for a version.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>The timestamp, or -1 for <see cref="CacheVersion.Unknown"/>.</returns>
        public static long GetTimestamp(CacheVersion version)
        {
            if (version == CacheVersion.Unknown)
                return -1;

            return VersionTimestamps[(int)version];
        }

        /// <summary>
        /// Gets the <see cref="CacheVersion"/> associated with the specified build name.
        /// </summary>
        /// <param name="buildName">The build name.</param>
        /// <returns>The version, or <see cref="CacheVersion.Unknown"/> if not found.</returns>
        public static CacheVersion GetFromBuildName(string buildName)
        {
            switch (buildName)
            {
                
                case "01.09.25.2247":
                case "01.10.12.2276":
                    return CacheVersion.HaloXbox;
                case "01.00.00.0564":
                    return CacheVersion.HaloPC;
                case "02.09.27.09809":
                    return CacheVersion.Halo2Xbox;
                case "11081.07.04.30.0934.main":
                    return CacheVersion.Halo2Vista;
                case "09699.07.05.01.1534.delta":
                   return CacheVersion.Halo3Beta;
                case "11855.07.08.20.2317.halo3_ship":
                case "12065.08.08.26.0819.halo3_ship":
                    return CacheVersion.Halo3Retail;
                case "13895.09.04.27.2201.atlas_relea":
                    return CacheVersion.Halo3ODST;
                case "1.106708 cert_ms23":
                    return CacheVersion.HaloOnline106708;
                case "1.235640 cert_ms23":
                    return CacheVersion.HaloOnline235640;
                case "0.0.1.301003 cert_MS26_new":
                    return CacheVersion.HaloOnline301003;
                case "0.4.1.327043 cert_MS26_new":
                    return CacheVersion.HaloOnline327043;
                case "8.1.372731 Live":
                    return CacheVersion.HaloOnline372731;
                case "0.0.416097 Live":
                    return CacheVersion.HaloOnline416097;
                case "10.1.430475 Live":
                    return CacheVersion.HaloOnline430475;
                case "10.1.454665 Live":
                    return CacheVersion.HaloOnline454665;
                case "10.1.449175 Live":
                    return CacheVersion.HaloOnline449175;
                case "11.1.498295 Live":
                    return CacheVersion.HaloOnline498295;
                case "11.1.530605 Live":
                    return CacheVersion.HaloOnline530605;
                case "11.1.532911 Live":
                    return CacheVersion.HaloOnline532911;
                case "11.1.554482 Live":
                    return CacheVersion.HaloOnline554482;
                case "11.1.571627 Live":
                    return CacheVersion.HaloOnline571627;
                case "12.1.700123 cert_ms30_oct19":
                    return CacheVersion.HaloOnline700123;
                case "11860.10.07.24.0147.omaha_relea":
                    return CacheVersion.HaloReach;
                case "Jun 24 2019 00:36:03":
                    return CacheVersion.HaloReachMCC824;
                default:
                    return CacheVersion.Unknown;
            }
        }

        /// <summary>
        /// Gets the version string corresponding to an <see cref="CacheVersion"/> value.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns>The version string.</returns>
        public static string GetBuildName(CacheVersion version)
        {
            switch (version)
            {
                case CacheVersion.Halo2Xbox:
                    return "02.09.27.09809";
                case CacheVersion.Halo2Vista:
                    return "11081.07.04.30.0934.main";
                case CacheVersion.Halo3Retail:
                    return "11855.07.08.20.2317.halo3_ship";
                case CacheVersion.Halo3ODST:
                    return "13895.09.04.27.2201.atlas_relea";
                case CacheVersion.HaloOnline106708:
                    return "1.106708 cert_ms23";
                case CacheVersion.HaloOnline235640:
                    return "1.235640 cert_ms23";
                case CacheVersion.HaloOnline301003:
                    return "0.0.1.301003 cert_MS26_new";
                case CacheVersion.HaloOnline327043:
                    return "0.4.1.327043 cert_MS26_new";
                case CacheVersion.HaloOnline372731:
                    return "8.1.372731 Live";
                case CacheVersion.HaloOnline416097:
                    return "0.0.416097 Live";
                case CacheVersion.HaloOnline430475:
                    return "10.1.430475 Live";
                case CacheVersion.HaloOnline454665:
                    return "10.1.454665 Live";
                case CacheVersion.HaloOnline449175:
                    return "10.1.449175 Live";
                case CacheVersion.HaloOnline498295:
                    return "11.1.498295 Live";
                case CacheVersion.HaloOnline530605:
                    return "11.1.530605 Live";
                case CacheVersion.HaloOnline532911:
                    return "11.1.532911 Live";
                case CacheVersion.HaloOnline554482:
                    return "11.1.554482 Live";
                case CacheVersion.HaloOnline571627:
                    return "11.1.571627 Live";
                case CacheVersion.HaloOnline700123:
                    return "12.1.700123 cert_ms30_oct19";
                case CacheVersion.HaloReach:
                    return "11860.10.07.24.0147.omaha_relea";
                case CacheVersion.HaloReachMCC824:
                    return "May 29 2019 00:44:52";
                case CacheVersion.HaloReachMCC887:
                    return "Jun 24 2019 00:36:03";
                case CacheVersion.HaloReachMCC1035:
                    return "Jul 30 2019 14:17:16";
                default:
                    return version.ToString();
            }
        }

		/// <summary>
		/// Checks if a <see cref="CacheVersion"/> is in Little-Endian or Big-Endian.
		/// </summary>
		/// <param name="version">The <see cref="CacheVersion"/> to check the endianness of.</param>
		/// <returns>True if the <see cref="CacheVersion"/> is Little-Endian, false otherwise.</returns>
		public static bool IsLittleEndian(CacheVersion version)
		{
			switch (version)
			{
				case CacheVersion.Halo3Retail:
				case CacheVersion.Halo3ODST:
				case CacheVersion.HaloReach:
					return false;
				case CacheVersion.Halo2Xbox:
				case CacheVersion.Halo2Vista:
				case CacheVersion.HaloOnline106708:
				case CacheVersion.HaloOnline235640:
				case CacheVersion.HaloOnline301003:
				case CacheVersion.HaloOnline327043:
				case CacheVersion.HaloOnline372731:
				case CacheVersion.HaloOnline416097:
				case CacheVersion.HaloOnline430475:
				case CacheVersion.HaloOnline454665:
				case CacheVersion.HaloOnline449175:
				case CacheVersion.HaloOnline498295:
				case CacheVersion.HaloOnline530605:
				case CacheVersion.HaloOnline532911:
				case CacheVersion.HaloOnline554482:
				case CacheVersion.HaloOnline571627:
				case CacheVersion.HaloOnline700123:
                case CacheVersion.HaloReachMCC824:
                    return true;
				default:
					throw new NotImplementedException(version.ToString());
			}
		}

        /// <summary>
        /// Determines whether a field exists in the given CacheVersion. Defines a priority : Version, Gen, Min/Max.
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool AttributeInCacheVersion(TagFieldAttribute attr, CacheVersion compare)
        {
            if(attr.Version != CacheVersion.Unknown)
            {
                // has a specific version specified.
                return attr.Version == compare;
            }
            else if(attr.Gen != CacheGeneration.Unknown)
            {
                // Has a generation specified
                return IsInGen(attr.Gen, compare);
            }
            else if(attr.MinVersion != CacheVersion.Unknown || attr.MaxVersion != CacheVersion.Unknown)
            {
                // Has a min or a max or both specified.
                return IsBetween(compare, attr.MinVersion, attr.MaxVersion);
            }
            else
            {
                // has no version attribute therefore it's valid in all cache versions
                return true;
            }
        }

		/// <summary>
		/// Compares two version numbers.
		/// </summary>
		/// <param name="lhs">The left-hand version number.</param>
		/// <param name="rhs">The right-hand version number.</param>
		/// <returns>A positive value if the left version is newer, a negative value if the right version is newer, and 0 if the versions are equivalent.</returns>
		public static int Compare(CacheVersion lhs, CacheVersion rhs)
        {
            // Assume the enum values are in order by release date
            return (int)lhs - (int)rhs;
        }

        /// <summary>
        /// Determines whether a version number is between two other version numbers (inclusive).
        /// </summary>
        /// <param name="compare">The version number to compare. If this is <see cref="CacheVersion.Unknown"/>, this function will always return <c>true</c>.</param>
        /// <param name="min">The minimum version number. If this is <see cref="CacheVersion.Unknown"/>, then the lower bound will be ignored.</param>
        /// <param name="max">The maximum version number. If this is <see cref="CacheVersion.Unknown"/>, then the upper bound will be ignored.</param>
        /// <returns></returns>
        public static bool IsBetween(CacheVersion compare, CacheVersion min, CacheVersion max)
        {
            if (compare == CacheVersion.Unknown)
                return true;
            if (min != CacheVersion.Unknown && Compare(compare, min) < 0)
                return false;
            return (max == CacheVersion.Unknown || Compare(compare, max) <= 0);
        }

        /// <summary>
        /// Determine whether a CacheVersion belongs to a CacheGeneration
        /// </summary>
        /// <param name="gen"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool IsInGen(CacheGeneration gen, CacheVersion compare)
        {
            if (gen == CacheGeneration.Unknown)
                return true;
            else
            {
                if (GetGeneration(compare) == gen)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Get CacheGeneration from CacheVersion
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static CacheGeneration GetGeneration(CacheVersion version)
        {
            switch (version)
            {
                case CacheVersion.HaloXbox:
                case CacheVersion.HaloPC:
                    return CacheGeneration.First;
                case CacheVersion.Halo2Vista:
                case CacheVersion.Halo2Xbox:
                    return CacheGeneration.Second;
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReach:
                    return CacheGeneration.Third;
                case CacheVersion.HaloOnline106708:
                case CacheVersion.HaloOnline235640:
                case CacheVersion.HaloOnline301003:
                case CacheVersion.HaloOnline327043:
                case CacheVersion.HaloOnline372731:
                case CacheVersion.HaloOnline416097:
                case CacheVersion.HaloOnline430475:
                case CacheVersion.HaloOnline454665:
                case CacheVersion.HaloOnline449175:
                case CacheVersion.HaloOnline498295:
                case CacheVersion.HaloOnline530605:
                case CacheVersion.HaloOnline532911:
                case CacheVersion.HaloOnline554482:
                case CacheVersion.HaloOnline571627:
                case CacheVersion.HaloOnline700123:
                    return CacheGeneration.HaloOnline;

                case CacheVersion.HaloReachMCC824:
                    return CacheGeneration.MCC;

                default:
                    return CacheGeneration.Unknown;
            }
        }

        /// <summary>
        /// tags.dat timestamps for each game version.
        /// Timestamps in here should correspond directly to <see cref="CacheVersion"/> enum values (excluding <see cref="CacheVersion.Unknown"/>).
        /// </summary>
        private static readonly long[] VersionTimestamps =
        {
            -1, // Halo Xbox
            -1, // Halo PC
            -1, // Halo2Xbox
            -1, // Halo2Vista
            -1, // Halo3Beta
            -1, // Halo3Retail
            -1, // Halo3ODST
            130713360239499012, // HaloOnline106708
            130772932862346058, // HaloOnline235640
            130785901486445524, // HaloOnline301003
            130800445160458507, // V0_4_1_327043_cert_MS26_new
            130814318396118255, // V8_1_372731_Live
            130829123589114103, // V0_0_416097_Live
            130834294034159845, // HaloOnline430475
            130844512316254660, // V10_1_454665_Live
            130851642645809862, // HaloOnline449175
            130858473716879375, // HaloOnline498295
            130868891945946004, // V11_1_530605_Live
            130869644198634503, // V11_1_532911_Live
            130879952719550501, // V11_1_554482_Live
            130881889330693956, // HaloOnline571627
            130930071628935939, // HaloOnline700123
            -1, // HaloReach
            -1, // HaloReachMCC824
            -1, // HaloReachMCC887
            -1, // HaloReachMCC1035
        };
    }

    public enum CacheVersion : int
    {
        Unknown = -1,
        HaloXbox,
        HaloPC,
        Halo2Xbox,
        Halo2Vista,
        Halo3Beta,
        Halo3Retail,
        Halo3ODST,
        HaloOnline106708,
        HaloOnline235640,
        HaloOnline301003,
        HaloOnline327043,
        HaloOnline372731,
        HaloOnline416097,
        HaloOnline430475,
        HaloOnline454665,
        HaloOnline449175,
        HaloOnline498295,
        HaloOnline530605,
        HaloOnline532911,
        HaloOnline554482,
        HaloOnline571627,
        HaloOnline700123,
        HaloReach,
        HaloReachMCC824,
        HaloReachMCC887,
        HaloReachMCC1035,
    }

    public enum CacheGeneration : int
    {
        Unknown = -1,
        First = 1,
        Second = 2,
        Third = 3,
        HaloOnline = 4,
        MCC = 5
    }
}
