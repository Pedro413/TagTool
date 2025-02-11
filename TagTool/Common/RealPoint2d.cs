using System;
using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Common
{
    public struct RealPoint2d : IEquatable<RealPoint2d>, IBlamType
	{
        public float X { get; set; }
        public float Y { get; set; }

        public RealVector2d IJ => new RealVector2d(X, Y);

        public RealPoint2d(float x, float y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(RealPoint2d other) =>
            (X == other.X) &&
            (Y == other.Y);

        public override bool Equals(object obj) =>
            obj is RealPoint2d ?
                Equals((RealPoint2d)obj) :
            false;

        public static bool operator ==(RealPoint2d a, RealPoint2d b) =>
            a.Equals(b);

        public static bool operator !=(RealPoint2d a, RealPoint2d b) =>
            !a.Equals(b);

        public override int GetHashCode() =>
            13 * 17 + X.GetHashCode()
               * 17 + Y.GetHashCode();

        public override string ToString() =>
            $"{{ X: {X}, Y: {Y} }}";

        public bool TryParse(HaloOnlineCacheContext cacheContext, List<string> args, out IBlamType result, out string error)
        {
            result = null;
            if (args.Count != 2)
            {
                error = $"{args.Count} arguments supplied; should be 2";
                return false;
            }
            else if (!float.TryParse(args[0], out float x))
            {
                error = $"Unable to parse \"{args[0]}\" (x) as `float`.";
                return false;
            }
            else if (!float.TryParse(args[1], out float y))
            {
                error = $"Unable to parse \"{args[1]}\" (y) as `float`.";
                return false;
            }
            else
            {
                result = new RealPoint2d(x, y);
                error = null;
                return true;
            }
        }

        public float[] ToArray() => new[] { X, Y };
    }
}
