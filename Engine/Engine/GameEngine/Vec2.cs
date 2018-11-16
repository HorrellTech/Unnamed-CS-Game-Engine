/*
 * A 2D Vector class for handling 2D points in space
 * (Unity 3D source has been used as reference for some of this code)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public struct Vec2 : IEquatable<Vec2>
    {
        public float x; // The X component of the Vector
        public float y; // The Y component of the Vector

        // Access the x or y component using [0] or [1] respectively.
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vec2 index!");
                }
            }

            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vec2 index!");
                }
            }
        }

        // Constructs a new vector with given x, y components.
        public Vec2(float x, float y) { this.x = x; this.y = y; }

        // Set x and y components of an existing Vector2.
        public void Set(float newX, float newY) { x = newX; y = newY; }

        // Linearly interpolates between two vectors.
        public static Vec2 Lerp(Vec2 a, Vec2 b, float t)
        {
            t = MathHelper.Clamp01(t);
            return new Vec2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }

        // Linearly interpolates between two vectors without clamping the interpolant
        public static Vec2 LerpUnclamped(Vec2 a, Vec2 b, float t)
        {
            return new Vec2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }

        // Moves a point /current/ towards /target/.
        public static Vec2 MoveTowards(Vec2 current, Vec2 target, float maxDistanceDelta)
        {
            Vec2 toVector = target - current;
            float dist = toVector.magnitude;
            if (dist <= maxDistanceDelta || dist == 0)
                return target;
            return current + toVector / dist * maxDistanceDelta;
        }

        // Makes this vector have a ::ref::magnitude of 1.
        public void Normalize()
        {
            float mag = magnitude;
            if (mag > kEpsilon)
                this = this / mag;
            else
                this = zero;
        }

        // Dot Product of two vectors.
        public static float Dot(Vec2 lhs, Vec2 rhs) { return lhs.x * rhs.x + lhs.y * rhs.y; }

        // Returns the length of this vector (RO).
        public float magnitude { get { return MathHelper.Sqrt(x * x + y * y); } }
        // Returns the squared length of this vector (RO).
        public float sqrMagnitude { get { return x * x + y * y; } }

        // Returns the angle in degrees between /from/ and /to/.
        public static float Angle(Vec2 from, Vec2 to)
        {
            // sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
            float denominator = MathHelper.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            if (denominator < kEpsilonNormalSqrt)
                return 0F;

            float dot = MathHelper.Clamp(Dot(from, to) / denominator, -1F, 1F);
            return MathHelper.Acos(dot) * MathHelper.Rad2Deg;
        }

        // Returns the distance between /a/ and /b/.
        public static float Distance(Vec2 a, Vec2 b) { return (a - b).magnitude; }

        // [Obsolete("Use Vector2.sqrMagnitude")]
        public static float SqrMagnitude(Vec2 a) { return a.x * a.x + a.y * a.y; }
        // [Obsolete("Use Vector2.sqrMagnitude")]
        public float SqrMagnitude() { return x * x + y * y; }

        // Returns a vector that is made from the smallest components of two vectors.
        public static Vec2 Min(Vec2 lhs, Vec2 rhs) { return new Vec2(MathHelper.Min(lhs.x, rhs.x), MathHelper.Min(lhs.y, rhs.y)); }

        // Returns a vector that is made from the largest components of two vectors.
        public static Vec2 Max(Vec2 lhs, Vec2 rhs) { return new Vec2(MathHelper.Max(lhs.x, rhs.x), MathHelper.Max(lhs.y, rhs.y)); }

        static readonly Vec2 zeroVector = new Vec2(0F, 0F);
        static readonly Vec2 oneVector = new Vec2(1F, 1F);
        static readonly Vec2 upVector = new Vec2(0F, 1F);
        static readonly Vec2 downVector = new Vec2(0F, -1F);
        static readonly Vec2 leftVector = new Vec2(-1F, 0F);
        static readonly Vec2 rightVector = new Vec2(1F, 0F);
        static readonly Vec2 positiveInfinityVector = new Vec2(float.PositiveInfinity, float.PositiveInfinity);
        static readonly Vec2 negativeInfinityVector = new Vec2(float.NegativeInfinity, float.NegativeInfinity);

        // Adds two vectors.
        public static Vec2 operator +(Vec2 a, Vec2 b) { return new Vec2(a.x + b.x, a.y + b.y); }
        // Subtracts one vector from another.
        public static Vec2 operator -(Vec2 a, Vec2 b) { return new Vec2(a.x - b.x, a.y - b.y); }
        // Multiplies one vector by another.
        public static Vec2 operator *(Vec2 a, Vec2 b) { return new Vec2(a.x * b.x, a.y * b.y); }
        // Divides one vector over another.
        public static Vec2 operator /(Vec2 a, Vec2 b) { return new Vec2(a.x / b.x, a.y / b.y); }
        // Negates a vector.
        public static Vec2 operator -(Vec2 a) { return new Vec2(-a.x, -a.y); }
        // Multiplies a vector by a number.
        public static Vec2 operator *(Vec2 a, float d) { return new Vec2(a.x * d, a.y * d); }
        // Multiplies a vector by a number.
        public static Vec2 operator *(float d, Vec2 a) { return new Vec2(a.x * d, a.y * d); }
        // Divides a vector by a number.
        public static Vec2 operator /(Vec2 a, float d) { return new Vec2(a.x / d, a.y / d); }
        // Returns true if the vectors are equal.
        public static bool operator ==(Vec2 lhs, Vec2 rhs)
        {
            // Returns false in the presence of NaN values.
            return (lhs - rhs).sqrMagnitude < kEpsilon * kEpsilon;
        }

        // Returns true if vectors are different.
        public static bool operator !=(Vec2 lhs, Vec2 rhs)
        {
            // Returns true in the presence of NaN values.
            return !(lhs == rhs);
        }

        // Shorthand for writing @@Vector2(0, 0)@@
        public static Vec2 zero { get { return zeroVector; } }
        // Shorthand for writing @@Vector2(1, 1)@@
        public static Vec2 one { get { return oneVector; } }
        // Shorthand for writing @@Vector2(0, 1)@@
        public static Vec2 up { get { return upVector; } }
        // Shorthand for writing @@Vector2(0, -1)@@
        public static Vec2 down { get { return downVector; } }
        // Shorthand for writing @@Vector2(-1, 0)@@
        public static Vec2 left { get { return leftVector; } }
        // Shorthand for writing @@Vector2(1, 0)@@
        public static Vec2 right { get { return rightVector; } }
        // Shorthand for writing @@Vector2(float.PositiveInfinity, float.PositiveInfinity)@@
        public static Vec2 positiveInfinity { get { return positiveInfinityVector; } }
        // Shorthand for writing @@Vector2(float.NegativeInfinity, float.NegativeInfinity)@@
        public static Vec2 negativeInfinity { get { return negativeInfinityVector; } }

        // *Undocumented*
        public const float kEpsilon = 0.00001F;
        // *Undocumented*
        public const float kEpsilonNormalSqrt = 1e-15f;

        /// *listonly*
        public override string ToString() { return String.Format("({0:F1}, {1:F1})", x, y); }
        // Returns a nicely formatted string for this vector.
        public string ToString(string format)
        {
            return String.Format("({0}, {1})", x.ToString(format), y.ToString(format));
        }

        // used to allow Vector2s to be used as keys in hash tables
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }

        // also required for being able to use Vector2s as keys in hash tables
        public override bool Equals(object other)
        {
            if (!(other is Vec2)) return false;

            return Equals((Vec2)other);
        }

        public bool Equals(Vec2 other)
        {
            return x.Equals(other.x) && y.Equals(other.y);
        }
    }
}
