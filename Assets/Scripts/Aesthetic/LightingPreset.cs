using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Lighting prefab", menuName = "Scriptables/Lighting preset", order = 1)]
public class LightingPreset : ScriptableObject
{
        public Color[] skies;
}
