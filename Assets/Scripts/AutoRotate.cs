using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    /// <summary>
    /// angular speed of the object in degrees par second
    /// </summary>
    [Tooltip("angular speed of the object in degrees par second")]
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float angle = this.speed;

        angle *= dt;

        if (GameController.Instance)
            angle *= GameController.Instance.Speed;
        
        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }
}
