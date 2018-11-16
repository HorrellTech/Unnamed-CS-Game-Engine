/*
 * A 2D Vector class for handling 2D points in space
 * (Unity 3D source has been used as reference to some of this code)
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
            t = MathHelper.Clamp(t);
            return new Vector2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }

        // Linearly interpolates between two vectors without clamping the interpolant
        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            return new Vector2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }

        // Moves a point /current/ towards /target/.
        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            Vector2 toVector = target - current;
            float dist = toVector.magnitude;
            if (dist <= maxDistanceDelta || dist == 0)
                return target;
            return current + toVector / dist * maxDistanceDelta;
        }
    }
}
