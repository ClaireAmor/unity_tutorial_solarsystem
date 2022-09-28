using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public static GameController Instance = null;
    
    [Range(-20, 20)]
    public float Speed = 1;

    private float _previousSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;

        if (InputController.Instance)
            InputController.Instance.OnUserPause += Pause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (this.Speed != 0)
        {
            this._previousSpeed = this.Speed;
            this.Speed = 0;
        }
        else
        {
            if (this._previousSpeed == 0)
                this.Speed = 1;
            else
                this.Speed = this._previousSpeed;


        }
    }
}
