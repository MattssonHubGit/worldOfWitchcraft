using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    public class GridTile  : MonoBehaviour
    {
        public GridTile neighbourN;
        public GridTile neighbourE;
        public GridTile neighbourS;
        public GridTile neighbourW;
        [Space]
        [SerializeField] private SpriteRenderer spriteRenderer;

    }
}

