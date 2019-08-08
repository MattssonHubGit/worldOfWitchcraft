using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridManager : MonoBehaviour
    {
        [Header("Level data")]
        [SerializeField] private Texture2D levelToSpawn;
        [SerializeField] private ColorToTileDataBase decoder;

        [Header("Tile adjustments")]
        [SerializeField] private float horizontalAdjustment = 1.25f;
        [SerializeField] private float verticalAdjustment = 1.25f;

        private GridTile[,] grid;

        private void Start()
        {
            GenerateGrid(levelToSpawn);
        }

        private void GenerateGrid(Texture2D map)
        {
            //Start with a clean array
            grid = new GridTile[levelToSpawn.width, levelToSpawn.height];

            //Fill it with tile prefabs depending on color
            for (int x = 0; x < map.width; x++)
            {
                for (int y = 0; y < map.height; y++)
                {
                    SpawnTile(x, y);
                }
            }

            //Set up neighbours
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    //North
                    if (y < grid.GetLength(1) - 1)
                    {
                        grid[x, y].neighbourN = grid[x, y + 1];
                    }

                    //East
                    if (x < grid.GetLength(0) - 1)
                    {
                        grid[x, y].neighbourE = grid[x + 1, y];
                    }

                    //South
                    if (y > 0)
                    {
                        grid[x, y].neighbourS = grid[x, y - 1];
                    }

                    //West
                    if (x > 0)
                    {
                        grid[x, y].neighbourW = grid[x - 1, y];
                    }
                }
            }
        }

        private void SpawnTile(int posX, int posY)
        {
            Color pixelColor = levelToSpawn.GetPixel(posX, posY);
            bool _tileSpawned = false;

            //Go through each color to prefab mapping and spawn a tile matching the color
            foreach (ColorToTileDictonaryBase colorTranslation in decoder.colorToPrefabMap)
            {
                if (colorTranslation.color.Equals(pixelColor))
                {
                    //Spawn tile, name it, add it to the grid array
                    GameObject _objTile = Instantiate(  colorTranslation.tilePrefab, 
                                                        new Vector3(posX + (posX * horizontalAdjustment), posY + (posY * verticalAdjustment), 0),
                                                        Quaternion.identity,
                                                        transform);
                    _objTile.name = colorTranslation.tilePrefab.name + " (" + posX + ", " + posY + ")";

                    GridTile _scrTile = _objTile.GetComponent<GridTile>();
                    grid[posX, posY] = _scrTile;

                    _tileSpawned = true;
                    continue;
                }

            }

            //If no tile has been spawned, spawn the default tile from the decoder (needed to keep grid neighbours)
            if (_tileSpawned == false)
            {
                //Spawn tile, name it, add it to the grid array
                GameObject _objTile = Instantiate(  decoder.zeroAlphaPrefab,
                                                    new Vector3(posX + (posX * horizontalAdjustment), posY + (posY * verticalAdjustment), 0),
                                                    Quaternion.identity,
                                                    transform);
                _objTile.name = decoder.zeroAlphaPrefab.name + " (" + posX + ", " + posY + ")";

                GridTile _scrTile = _objTile.GetComponent<GridTile>();
                grid[posX, posY] = _scrTile;


                _tileSpawned = true;
            }

        }
    }
}


