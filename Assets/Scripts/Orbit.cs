using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public PlanetOrbitPreset preset;
    [Tooltip("Child planet to move")]
    private GameObject Planet;

    private float allAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        this.Planet = GameObject.Instantiate(preset.PlanetPrefab, this.transform);
        this.Planet.name = preset.PlanetPrefab.name;
    }
    
    // Update is called once per frame
    void Update()
    {
        Rotate();
        NumberOfYear();
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
            angle *= GameController.Instance.speed;
        
        this.transform.Rotate(Vector3.up, angle, Space.Self);
        
        allAngle += angle;
    }

    void NumberOfYear()
    {
        int totalYear = (int) allAngle/ 360;
        if (this.gameObject.name == "earth_orbit")
            Debug.Log("La terre a fait " + totalYear);
    }
}
