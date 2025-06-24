using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRPointerVisualizer : MonoBehaviour
{
    public Transform rayTransform;
    public LineRenderer linePointer = null;
    public float rayDrawDistance = 2.5f;
    [SerializeField] private OVRGazePointer _ovrGazePointer = null;
    void LateUpdate()
    {
        Ray ray = new Ray(rayTransform.position, rayTransform.forward);
        linePointer.SetPosition(0, ray.origin);
        if (!_ovrGazePointer.hidden)
        {
            linePointer.SetPosition(1, _ovrGazePointer.transform.position);
            return;
        }
        linePointer.SetPosition(1, ray.origin + ray.direction * rayDrawDistance);
    }
}
