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
       
    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hitinfo;
        // bool hit = Physics.Raycast(ray, out hitinfo, float.MaxValue);
        // if (hit && hitinfo.collider != null)
        //
        
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
