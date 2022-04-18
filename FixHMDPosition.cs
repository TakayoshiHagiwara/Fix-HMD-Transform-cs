// --------------------------------------------------
// Author:      Takayoshi Hagiwara (Toyohashi University of Technology)
// Created:     2020/11/22
// Summary:     Fix the HMD in the desired location
// Environment: Unity 2019 or Later
// --------------------------------------------------

using UnityEngine;
using UnityEngine.XR;

public class FixHMDPosition : MonoBehaviour
{
    [SerializeField, Tooltip("Fixing Location")]
    public Transform fixedTransform;
    [SerializeField, Tooltip("Offset of the fixing location")]
    public Vector3 offset;

    void Update()
    {
        Vector3 basePos = fixedTransform.position;

        Vector3 trackingPos;
        TryGetCenterEyePosition(out trackingPos);

        // Subtract the position of HMD from the fixed position to disable the HMD movement
        transform.position = basePos - trackingPos;
        transform.position += offset;
    }

    /// <summary>
    /// Get the center position of the eye of the HMD
    /// </summary>
    /// <param name="position">Center eye position of the HMD</param>
    /// <returns>If center position of eye is available, return true, else false.</returns>
    bool TryGetCenterEyePosition(out Vector3 position)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.centerEyePosition, out position))
                return true;
        }
        position = Vector3.zero;
        return false;
    }

    /// <summary>
    /// Get the center rotation of the eye of the HMD
    /// </summary>
    /// <param name="rotation">Center eye rotation of the HMD</param>
    /// <returns>If center rotation of eye is available, return true, else false.</returns>
    bool TryGetCenterEyeRotation(out Quaternion rotation)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.CenterEye);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.centerEyeRotation, out rotation))
                return true;
        }
        rotation = Quaternion.identity;
        return false;
    }
}
