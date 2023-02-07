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

        public ShapeType[] ShapeTypes => Enum.GetValues(typeof(ShapeType)) as ShapeType[];
        public AssetReference GetShapeSpriteReference(ShapeType type)
        {
            return sprites.FirstOrDefault(s => s.type == type)?.spriteReference;
        }
        public int[] ShapeColors => colors.Select(c => c.index).ToArray();
        public Color GetShapeColor(int index)
        {
            var shapeColor = colors.FirstOrDefault(c => c.index == index);
            return shapeColor != null ? shapeColor.color : Color.black;
        }
    }
}
