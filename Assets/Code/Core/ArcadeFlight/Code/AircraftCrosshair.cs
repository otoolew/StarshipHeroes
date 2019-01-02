using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftCrosshair : MonoBehaviour
{
    [SerializeField]
    private Image crosshairImage;
    public Image CrosshairImage
    {
        get { return crosshairImage; }
        private set { crosshairImage = value; }
    }
    [SerializeField]
    private bool crosshair;
    public bool Crosshair
    {
        get { return crosshair; }
        private set { crosshair = value; }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
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
