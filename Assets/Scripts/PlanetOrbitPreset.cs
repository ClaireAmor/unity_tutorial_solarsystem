using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetOrbitPreset : ScriptableObject
{
    [Range(-10000,10000)]
    [Tooltip("Speed of rotation of the orbit in dregrees per second")]
    public float OrbitalSpeed;

    [Range(0, 10000)]
    [Tooltip("Distance of the planets in units")]
    public float OrbitRadius;

}
