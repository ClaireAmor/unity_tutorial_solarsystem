using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public PlanetOrbitPreset preset;
    [Tooltip("Child planet to move")]
    public GameObject Planet;

    private float allAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AutoRotate>().speed = this.preset.OrbitalSpeed;
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
        
        float message = allAngle += angle;
        int totalYear = (int) message/ 360;
        if (this.gameObject.name == "earth_orbit")
            Debug.Log("La terre a fait " + totalYear);
    }

    void NumberOfYear()
    {
       
        
    }
}
