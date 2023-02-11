using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = "ShapeSettings", menuName = "Game Settings/Shape Settings")]
    public class ShapeSettings : ScriptableObject
    {
        [Serializable]
        private class ShapeSprite
        {
            public ShapeType type;
            public AssetReference spriteReference;
        }
        [Serializable]
        private class ShapeColor
        {
            public int index;
            public Color color;
        }

        [SerializeField]
        private ShapeSprite[] sprites;
        [SerializeField]
        private ShapeColor[] colors;

        private ShapeType[] shapeTypes;
        public ShapeType[] ShapeTypes => (shapeTypes == null || shapeTypes.Length == 0) ? (shapeTypes = sprites.Select(s => s.type).ToArray()) : shapeTypes;
        private ShapeType[] availableShapeTypes;
        public ShapeType[] AvailableShapeTypes => (availableShapeTypes == null || availableShapeTypes.Length == 0) ? (availableShapeTypes = ShapeTypes.Where(t => t != ShapeType.None).ToArray()) : availableShapeTypes;
        public AssetReference GetShapeSpriteReference(ShapeType type)
        {
            return sprites.FirstOrDefault(s => s.type == type)?.spriteReference;
        }

        private int[] shapeColors;
        public int[] ShapeColors => (shapeColors == null || shapeColors.Length == 0) ? (shapeColors = colors.Select(c => c.index).ToArray()) : shapeColors;
        private int[] availableShapeColors;
        public int[] AvailableShapeColors => (availableShapeColors == null || availableShapeColors.Length == 0) ? (availableShapeColors = ShapeColors.Where(c => c != 0).ToArray()) : availableShapeColors;
        public Color GetShapeColor(int index)
        {
            var shapeColor = colors.FirstOrDefault(c => c.index == index);
            return shapeColor != null ? shapeColor.color : Color.clear;
        }

        [SerializeField]
        private AssetReference shapeObjectPrefab;
        public AssetReference ShapeObjectPrefab => shapeObjectPrefab;
    }
}
