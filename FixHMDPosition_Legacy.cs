// --------------------------------------------------
// Author:      Takayoshi Hagiwara (Toyohashi University of Technology)
// Created:     2020/11/22
// Summary:     (Legacy) Fix the HMD in the desired location
// Environment: Unity 2018 or Earlier
// --------------------------------------------------

using UnityEngine;
using UnityEngine.XR;

public class FixHMDPositionLegacy : MonoBehaviour {

    [SerializeField, Tooltip("Fixing Location")]
    public Transform fixedTransform;
    [SerializeField, Tooltip("Offset of the fixing location")]
    public Vector3 offset;

    void Update()
    {
        Vector3 basePos = fixedTransform.position;
        //Quaternion baseRotation = TrackingTarget.rotation;

        Vector3 trackingPos = InputTracking.GetLocalPosition(XRNode.CenterEye);
        //Quaternion trackingRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);

        // Subtract the position of HMD from the fixed position to disable the HMD movement
        transform.position = basePos - trackingPos;
        transform.position += offset;
    }
}
