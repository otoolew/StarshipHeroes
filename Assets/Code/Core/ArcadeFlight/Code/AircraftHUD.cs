using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftHUD : MonoBehaviour
{
    [SerializeField]
    private Aircraft aircraft;
    public Aircraft Aircraft
    {
        get { return aircraft; }
        private set { aircraft = value; }
    }

    [SerializeField]
    private Image crosshairImage;
    public Image CrosshairImage
    {
        get { return crosshairImage; }
        private set { crosshairImage = value; }
    }
    [SerializeField]
    private Text speedReadout;
    public Text SpeedReadout
    {
        get { return speedReadout; }
        private set { speedReadout = value; }
    }
    [SerializeField]
    private bool crosshair;
    public bool Crosshair
    {
        get { return crosshair; }
        private set { crosshair = value; }
    }
    private void Awake()
    {
        
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        speedReadout.text = string.Format("THR: {0}\nSPD: {1}", (aircraft.Throttle * 100.0f).ToString("000"), aircraft.Velocity.magnitude.ToString("000"));
        if (crosshair)
        {
            crosshairImage.enabled = true;
            crosshairImage.transform.position = Input.mousePosition;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
