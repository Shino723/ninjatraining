using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenUI : MonoBehaviour
{
    public Transform cameraRig;
    public Canvas uiCanvas;

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas.transform.position = cameraRig.position + cameraRig.forward * 140.0f;
        uiCanvas.transform.LookAt(cameraRig);
        uiCanvas.transform.Rotate(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
