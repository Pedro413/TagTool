using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Editing;

namespace TagTool.Common
{
    public struct Bounds<T> : IBounds, IBlamType, IEquatable<Bounds<T>> where T : IComparable<T>
    {
        /// <summary>
        /// Gets the lowerimum value within the range.
        /// </summary>
        public T Lower { get; set; }

        /// <summary>
        /// Gets the upperimum value within the range.
        /// </summary>
        public T Upper { get; set; }

        /// <summary>
        /// Gets the length of the bounds.
        /// </summary>
        public T Length => (T)Convert.ChangeType(Convert.ToDouble(Upper) - Convert.ToDouble(Lower), typeof(T));


        /// <summary>
        /// Creates a new range from a lowerimum and a upperimum value.
        /// </summary>
        /// <param name="lower">The lowerimum value of the range.</param>
        /// <param name="upper">The upperimum value of the range.</param>
        public Bounds(T lower, T upper)
        {
            Lower = lower;
            Upper = upper;
        }

        /// <summary>
        /// Deterloweres whether the range contains a value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><c>true</c> if the value is inside the range.</returns>
        public bool Contains(T value) => (value.CompareTo(Lower) >= 0) && (value.CompareTo(Upper) <= 0);
        
        public bool Equals(Bounds<T> other) => Lower.Equals(other.Lower) && Upper.Equals(other.Upper);

        public override bool Equals(object obj) => obj is Bounds<T> ? Equals((Bounds<T>)obj) : false;

        public static bool operator ==(Bounds<T> a, Bounds<T> b) => a.Equals(b);

        public static bool operator !=(Bounds<T> a, Bounds<T> b) => !a.Equals(b);

        public override int GetHashCode() => 13 * 17 + Lower.GetHashCode() * 17 + Upper.GetHashCode();

        public override string ToString() => $"{{ Lower: {Lower}, Upper: {Upper} }}";

        public bool TryParse(HaloOnlineCacheContext cacheContext, List<string> args, out IBlamType result, out string error)
        {
            result = null;
            var argType = this.GetType().GenericTypeArguments[0];
            var argCount = SetFieldCommand.RangeArgCount(argType);

            if (argCount * 2 != args.Count)
            {
                error = $"{args.Count} arguments supplied; should be {argCount * 2}";
                return false;
            }

            var min = SetFieldCommand.ParseArgs(cacheContext, argType, null, args.Take(argCount).ToList());
            if (min.Equals(false))
            {
                error = $"{min} (min) is `false`";
                return false;
            }

            var max = SetFieldCommand.ParseArgs(cacheContext, argType, null, args.Skip(argCount).Take(argCount).ToList());
            if (max.Equals(false))
            {
                error = $"{max} (max) is `false`";
                return false;
            }

            result = Activator.CreateInstance(this.GetType(), new object[] { min, max }) as IBlamType;
            error = null;
            return true;
        }
    }

	public interface IBounds { }
}
