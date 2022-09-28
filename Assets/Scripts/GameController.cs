using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public delegate void SpeedEvent(float newSpeed);

    public event SpeedEvent onSpeedChanged;

    private float _speed = 1;

    public float speed
    {
        get => _speed;
        set
        {
            if (this.onSpeedChanged != null && value != this._speed)
            {
                this.onSpeedChanged.Invoke(value);
            }

            this._speed = value;
        }
    }
    
    private static GameController _instance ;

    public static GameController Instance
    {
        get
        {
            if (_instance == null) 
                _instance = FindObjectOfType<GameController>();
            return _instance;

        }
        private set
        {
            _instance = value;
        }
    }


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
        if (this.speed != 0)
        {
            this._previousSpeed = this.speed;
            this.speed = 0;
        }
        else
        {
            if (this._previousSpeed == 0)
                this.speed = 1;
            else
                this.speed = this._previousSpeed;


        }
    }
}
