using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridTile 
    {
        public GridTile neighbourN;
        public GridTile neighbourE;
        public GridTile neighbourS;
        public GridTile neighbourW;

        [SerializeField] private SpriteRenderer spriteRenderer { get; }

    }
}

