namespace MatchAll
{
#if !UNITY_5_3_OR_NEWER
    public struct Vector2Int
    {
        public int x;
        public int y;
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new Vector2Int(a.x + b.x, a.y + b.y);
        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new Vector2Int(a.x - b.x, a.y - b.y);
        public static Vector2Int operator *(Vector2Int a, int b) => new Vector2Int(a.x * b, a.y * b);
        public static Vector2Int operator *(int a, Vector2Int b) => new Vector2Int(a * b.x, a * b.y);
        public readonly static Vector2Int zero = new Vector2Int(0, 0);
        public readonly static Vector2Int one = new Vector2Int(1, 1);
    }
#endif
}
