namespace MatchAll
{
#if !UNITY_5_3_OR_NEWER
    public struct Vector2
    {
        public float x;
        public float y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);
        public static Vector2 operator *(float a, Vector2 b) => new Vector2(a * b.x, a * b.y);
        public readonly static Vector2 zero = new Vector2(0, 0);
        public readonly static Vector2 one = new Vector2(1, 1);
    }
#endif
}
