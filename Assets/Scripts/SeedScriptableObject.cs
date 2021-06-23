using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Seed", order = 1)]
public class SeedScriptableObject : ScriptableObject
{
    public string Name;
    public float GrowTime;
    public GameObject SeedPrefab;
}
