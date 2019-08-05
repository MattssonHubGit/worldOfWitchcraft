using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        //test
        [SerializeField] private Texture2D levelToSpawn;

        [SerializeField] private ColorToTileDataBase decoder;

        private void Start()
        {
            GenerateGrid(levelToSpawn);
        }

        private void GenerateGrid(Texture2D map)
        {
            for (int i = 0; i < map.width; i++)
            {
                for (int j = 0; j < map.height; j++)
                {
                    SpawnTile(i, j);
                }
            }
        }

        private void SpawnTile(int posX, int posY)
        {
            Color pixelColor = levelToSpawn.GetPixel(posX, posY);

            if (pixelColor.a == 0)
            {
                GameObject _objTile = Instantiate(decoder.zeroAlphaPrefab, new Vector3(posX, posY, 0), Quaternion.identity, transform);
                _objTile.name = "Gridtile: " + posX + ", " + posY;
                return;
            }

            foreach (ColorToTileDictonaryBase colorTranslation in decoder.colorToPrefabMap)
            {
                if (colorTranslation.color.Equals(pixelColor))
                {
                    GameObject _objTile = Instantiate(colorTranslation.tilePrefab, new Vector3(posX, posY, 0), Quaternion.identity, transform);
                    _objTile.name = "Gridtile: " + posX + ", " + posY;
                }
            }


        }
    }
}


