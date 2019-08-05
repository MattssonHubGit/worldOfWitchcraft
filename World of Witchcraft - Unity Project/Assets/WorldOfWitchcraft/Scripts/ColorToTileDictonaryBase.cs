using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    [CreateAssetMenu()]
    public class ColorToTileDataBase : ScriptableObject
    {
        [SerializeField] public GameObject zeroAlphaPrefab;
        [SerializeField] public List<ColorToTileDictonaryBase> colorToPrefabMap = new List<ColorToTileDictonaryBase>();
    }
}

