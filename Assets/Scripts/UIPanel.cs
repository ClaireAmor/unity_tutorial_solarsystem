using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public UnityEngine.UI.Button pauseButton;
    public UnityEngine.UI.Slider speedSlider;
    public TMPro.TextMeshProUGUI speedLabel;
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.onSpeedChanged += RefrechFromSpeed;
    }

    private void RefrechFromSpeed(float newSpeed)
    {
        this.speedLabel.text = "SPEED = " + newSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
