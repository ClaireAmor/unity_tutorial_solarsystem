using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController _instance = null;

    public static InputController Instance
    {
        get
        {
            if (_instance == null) 
                _instance = FindObjectOfType<InputController>();
            return _instance;

        }
        private set
        {
            _instance = value;
        }
    }

    public delegate void InputEvent(string userAction);
    public event InputEvent OnUserInput;
    
    public delegate void InputSpecificEvent();
    public event InputSpecificEvent OnUserPause;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the singleton instance if not set yet
        if (InputController.Instance == null)
            InputController.Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.OnUserInput != null)
                this.OnUserInput.Invoke("Pause");
            
            if (this.OnUserPause != null)
                this.OnUserPause.Invoke();
            /*if (GameController.Instance)
                GameController.Instance.Pause();*/
        }
    }
}
