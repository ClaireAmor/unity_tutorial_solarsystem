using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public PlanetOrbitPreset preset;
    [Tooltip("Child planet to move")]
    public GameObject Planet;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AutoRotate>().speed = this.preset.OrbitalSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        Rotate();
        this.MovePlanetToRadius();
    }

    void MovePlanetToRadius()
    {
        this.Planet.transform.localPosition = new Vector3(this.preset.OrbitRadius, 0, 0);
    }
    
    void Rotate()
    {
        float dt = Time.deltaTime;
        float angle = this.preset.OrbitalSpeed;

        angle *= dt;

        if (GameController.Instance)
            angle *= GameController.Instance.Speed;
        
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }
}
