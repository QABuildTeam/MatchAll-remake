using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchAll.Views
{
    public class FieldBackground : MonoBehaviour
    {
        [SerializeField]
        private Transform[] bgTiles;
        [SerializeField]
        private Transform centralTile;
        [SerializeField]
        private float tileStep;

        public Vector3 Position
        {
            get => centralTile.position;
            set => AdjustBgTiles(value);
        }

        private void AdjustBgTiles(Vector3 cameraPosition)
        {
            int dx = 0;
            int dy = 0;
            Rect centralRect = new Rect(centralTile.position.x - tileStep / 2, centralTile.position.y - tileStep / 2, tileStep, tileStep);
            if (cameraPosition.x < centralRect.xMin)
            {
                dx = -1;
            }
            else if (cameraPosition.x > centralRect.xMax)
            {
                dx = 1;
            }
            if (cameraPosition.y < centralRect.yMin)
            {
                dy = -1;
            }
            else if (cameraPosition.y > centralRect.yMax)
            {
                dy = 1;
            }
            if (dx != 0 || dy != 0)
            {
                Vector3 relocator = new Vector3(dx * tileStep, dy * tileStep, 0);
                for (int i = 0; i < bgTiles.Length; ++i)
                {
                    bgTiles[i].position += relocator;
                }
            }
        }
    }
}
