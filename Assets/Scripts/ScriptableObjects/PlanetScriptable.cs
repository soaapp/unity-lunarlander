using UnityEngine;

// Scriptable Object is a way to store data that can be shared between scenes
[CreateAssetMenu(fileName = "New Planet", menuName = "ScriptableObjects/Planet", order = 0)]
public class PlanetScriptable : ScriptableObject
{
    // Header is used to group related fields in the inspector literally just to organize
    [Header("Planet Properties")]
    public string PlanetName;
    public float GravityInGs = 1f; // 1g = Earth, 0.166g = Moon, etc.
    public float Mass = 1.0f;

    
    [Header("Terrain Settings")]
    public TerrainType Terrain;
}

// We didnt use [SerializeObject] private cause it wouldnt really be proper use of the scope
public enum TerrainType
{
    Rocky,
    GasGiant,
    Ice
}

