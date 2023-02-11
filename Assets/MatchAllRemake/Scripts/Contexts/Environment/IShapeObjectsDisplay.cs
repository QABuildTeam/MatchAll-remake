namespace MatchAll
{
    public interface IShapeObjectsDisplay
    {
        void CreateShapeObject(ShapeType shapeType, int colorIndex, int x, int y);
        void SetShapeColor(int x, int y, int colorIndex);
    }
}
